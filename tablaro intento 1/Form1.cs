using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace tablaro_intento_1
{
    public partial class Form1 : Form
    {
        


        Stack<int> Acartas = new Stack<int>();

        Random rrnd = new Random();

        int i = 0;

        const int CANTIDAD_CARTAS = 54;
       
        private PictureBox[] tabla;


        public Form1()
        {
            InitializeComponent();
            
            tabla = new PictureBox[25];
            inicializarTabla();
        }

        private void inicializarTabla()
        {
            int r=0, c = 0;

            int[] cartas = new int[34];
          

            for(int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = i + 1;
            }

            Random rnd = new Random();
            int a, aux;
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }
            for (int i = 0; i < tabla.Length; i++) 
            {
                tabla[i] = new PictureBox();
                tabla[i].Location = new System.Drawing.Point(100+(c*90), 25+(r*125));
                tabla[i].Name = "picTabla"+i;
                tabla[i].Size = new System.Drawing.Size(85, 120);
                tabla[i].TabIndex = 0+i;
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].TabStop = false;
                tabla[i].Image = Image.FromFile(@"cartas\"+(cartas[i])+".jpg");
                this.Controls.Add(tabla[i]);
                c++;
                if (c==5) 
                {
                    r++;
                    c = 0;
                }
            }
        
        }
        SoundPlayer sonido;
        private void Form1_Load(object sender, EventArgs e)
        {

            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(150, 200);
            this.listView1.LargeImageList = this.imageList1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = (54 - Acartas.Count()).ToString();


            bool bandera = false;

            if (Acartas.Count() == 54){
                bandera = true;

                MessageBox.Show("Son todas las cartas", "Aviso", MessageBoxButtons.OK , MessageBoxIcon.Information);
            }

            while (!bandera){


                int num = rrnd.Next(1, 54);


                if (!Acartas.Contains(num)){

                    pbcarta.Image = Image.FromFile(@"cartas\" +num+ ".jpg");

                    pbcarta.SizeMode = PictureBoxSizeMode.StretchImage;

                    Acartas.Push(num);

                    this.imageList1.Images.Add(Image.FromFile(@"cartas\" +num + ".jpg"));

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;

                    this.listView1.Items.Add(item);

                    bandera = true;

                    i++;
                }
            }
        }


        

        private void button2_Click(object sender, EventArgs e)
        {

            Acartas.Clear();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            pbcarta.Image = null;
            i = 0;
            label1.Text = "";
        }
          
        private void button3_Click(object sender, EventArgs e)
        {
            
           

        }
    }
}
