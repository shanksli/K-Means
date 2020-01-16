using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using delaunay_LTENative;
using System.Data.OleDb;
using System.IO;

namespace Kmeans_new
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable table;
        private int TableWidth;
        private int TableLength;
        Bitmap bmImage;
        List<InputDataSample> sampleList = new List<InputDataSample>(); //存放所有用于聚类的原始点
        List<InputDataSample> CenterList = new List<InputDataSample>();//存放每类的质心
        Color[] colorArray = { Color.Red,Color.OrangeRed, Color.Orange, Color.Yellow,Color.YellowGreen, Color.GreenYellow, Color.LightGreen, Color.Green, Color.Blue   };
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文件|*.CSV";
            fd.Title = "打开文件夹";
            string path = "";
            fd.FilterIndex = 1;
            fd.InitialDirectory = "C:\\Users\\Administrator\\Documents\\Magnifi\\Projects\\Default\\DemoData4.3";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                path = fd.FileName;
                table = ImportCsvToDataTable(path);
            }
            TableWidth = table.Rows.Count;
            TableLength = table.Columns.Count;
            for (int i = 0; i < TableWidth - 1; i++)
            {
                for (int j = 0; j < TableLength - 1; j++)
                {
                    InputDataSample ids = new InputDataSample();
                    ids.x = i;
                    ids.y = j;
                    ids.value = Convert.ToInt16(table.Rows[i][j].ToString());
                    ids.color = Color.Green;
                    sampleList.Add(ids);
                }
            }
           //bmImage  = new Bitmap(TableWidth, TableLength);
        }



        /// <summary>
        /// Stream读取.csv文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public DataTable ImportCsvToDataTable(string filePath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                DataTable dt = new DataTable();
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                //记录每次读取的一行记录
                string strLine = "";
                //记录每行记录中的各字段内容
                string[] aryLine;
                //标示列数
                int columnCount = 0;
                int firstCount = 0;
                Boolean first = true;
                //逐行读取CSV中的数据
                while ((strLine = sr.ReadLine()) != null)
                {
                    aryLine = strLine.Split(',');

                    columnCount = aryLine.Length;
                    if (first)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                        }
                        first = false;
                        firstCount = columnCount;
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        if (firstCount < columnCount)
                        {
                            throw new Exception("最大列数不能大于表格起始列数");
                        }
                        for (int j = 0; j < columnCount - 1; j++)
                        {
                            string str = aryLine[j];
                            dr[j] = str;
                        }
                        dt.Rows.Add(dr);
                    }


                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
                //MessageBox.Show(e.ToString());
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

        }

        /// <summary>
        /// 生成质心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateCeterButton_Click(object sender, EventArgs e)
        {
            CenterList.Clear();
            int k = Convert.ToInt16(KTextBox.Text);
            Random rand = new Random();
            for(int i=0;i<k;i++)
            {
                InputDataSample ids_Center = new InputDataSample();
                ids_Center.x = rand.Next(TableWidth - 1);
                ids_Center.y = rand.Next(TableLength - 1);
                //ids_Center.value = Convert.ToInt16(table.Rows[ids_Center.x][ids_Center.x].ToString());
                ids_Center.value = i - 2;
                ids_Center.type = i;
                ids_Center.colorType = i;
                if(i<colorArray.Count())
                {
                    ids_Center.color = colorArray[CenterList.Count()];
                    
                }
                else
                {
                    ids_Center.color = Color.FromArgb(rand.Next(1, 255), rand.Next(1, 255), rand.Next(1, 255));
                }
                CenterList.Add(ids_Center);
            }
            
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaculateButton_Click(object sender, EventArgs e)
        {
            
            
            //开始聚类
            double Lmin = 9999999F;
            
            for (int i=0;i<10;i++)
            {
                
                foreach(InputDataSample ids_sample in  sampleList)
                {
                    Lmin = 9999999F;
                    foreach(InputDataSample ids_Center in CenterList)
                    {
                        double SampleValue = ids_sample.value;
                        double CenterValue = ids_Center.value;
                        double Ltemp = Math.Sqrt((SampleValue - CenterValue) * (SampleValue - CenterValue));
                        if(Ltemp<Lmin)
                        {
                            Lmin = Ltemp;
                            ids_sample.type = ids_Center.type;
                            ids_sample.color = ids_Center.color;
                        }
                    }
                }
                //重算每组质心
                double sumx = 0;
                double sumy = 0;
                double sumValue = 0;
                foreach(InputDataSample ids_Center in  CenterList)
                {
                    
                    sumx = 0;
                    sumy = 0;
                    sumValue = 0;
                    List<InputDataSample> idsList = sampleList.FindAll(ids => ids.type == ids_Center.type);
                    if(idsList.Count()>0)
                    {
                        foreach(InputDataSample idsTemp in idsList)
                        {
                            sumx = sumx + idsTemp.x;
                            sumy = sumy + idsTemp.y;
                            sumValue = sumValue + idsTemp.value;
                        }
                        sumValue = sumValue / idsList.Count();
                        ids_Center.value = sumValue;
                    }
                }
                if (CenterList.Count > 0)
                {
                    Color c;
                    for (int j = 0; j < Convert.ToInt16(KTextBox.Text); j++)
                    {
                        for (int l = 1; l < Convert.ToInt16(KTextBox.Text); l++)
                        {
                            if (CenterList[j].value < CenterList[l].value)
                            {
                                int tp = CenterList[j].colorType;
                                CenterList[j].colorType = CenterList[l].colorType;
                                CenterList[l].colorType = tp;
                                //CenterList[j].color = colorArray[CenterList[j].colorType];
                                //CenterList[l].color = colorArray[CenterList[l].colorType];
                            }
                        }
                    }
                    for (int j = 0; j < Convert.ToInt16(KTextBox.Text); j++)
                    {
                        CenterList[j].color = colorArray[CenterList[j].colorType];
                    }

                }

            }

            
                    DrawPicture();
        }

        private void DrawPicture()
        {
            List<InputDataSample> idsList = new List<InputDataSample>();
            
            Bitmap pic = new Bitmap(TableLength, TableWidth, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            //画点
            if(sampleList.Count()>0)
            {
               foreach(InputDataSample ids in sampleList)
                {
                    pic.SetPixel(ids.y, TableWidth-1-ids.x, ids.color);
                }
                pic.Save(@"e:\l.png");


                 string picName = PGNNameTextBox.Text;
                 picName = "e:\\" + picName + ".png";
                pic.Save(picName);
                int[] b = new int[TableWidth * TableLength];
                GetDataPicture(TableWidth,TableLength,b );
                pictureBox1.Load(picName);
            }

        }

        public Bitmap GetDataPicture(int w, int h, int[] data)
        {
            Bitmap pic = new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            Color c;
            for (int i = 0; i < data.Length; i++)
            {
                //c = Color.FromArgb(data[i]);


                if (data[i] < -1000)
                    c = Color.Red;
                else if (data[i] < -800)
                    c = Color.OrangeRed;
                else if (data[i] < -500)
                    c = Color.HotPink;


                else if (data[i] < 600)
                    c = Color.Green;
                else if (data[i] < 800)
                    c = Color.LightSkyBlue;

                else
                    c = Color.Blue;


                pic.SetPixel(i % h, i / h, c);
            }
            pic.Save(@"e:\p.png");
            return pic;
        }
    }
}
