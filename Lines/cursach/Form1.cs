using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace cursach
{

    public partial class Form1 : Form
    {

        static public Button[,] ButtonMap = new Button[11,11];
        public int[,] Map = new int[11,11];
        static public int[,] MatrixSm = new int[121,121];
        static public int[] visited = new int[121];
        public int prov;
        public int check;
        public int score = 0;
        public int Bomb = 0;
        public string PlayerName { get; set; }
        public int ColorCount { get; set; }
        public Form1()
        {

            InitializeComponent();
        }


        public void Generation()
        {
            Random random1 = new Random();
            for (int i = 0; i < 11; i++)
            {
                ButtonMap[0, i].BackColor = Color.Black;
                ButtonMap[i, 0].BackColor = Color.Black;
                ButtonMap[i, 10].BackColor = Color.Black;
                ButtonMap[10, i].BackColor = Color.Black;

            }
            while (true)
            {
                int x1 = random1.Next(1, 10);
                int y1 = random1.Next(1, 10);

                if (Map[x1, y1] == 0)
                {
                    ButtonMap[x1, y1].BackColor = Color.Red;
                    Map[x1, y1] = 1;
                    break;
                }
            }
            Random random2 = new Random();
            while (true)
            {
                int x2 = random2.Next(1, 10);
                int y2 = random2.Next(1, 10);

                if (Map[x2, y2] == 0)
                {
                    ButtonMap[x2, y2].BackColor = Color.Yellow;
                    Map[x2, y2] = 1;
                    break;
                }
            }
            Random random = new Random();
            while (true)
            {
                int x = random.Next(1, 10);
                int y = random.Next(1, 10);

                if (Map[x, y] == 0)
                {
                    ButtonMap[x, y].BackColor = Color.Blue;
                    Map[x, y] = 1;
                    break;
                }
            }
            if (ColorCount == 4)
            {
                while (true)
                {
                    int x = random.Next(1, 10);
                    int y = random.Next(1, 10);

                    if (Map[x, y] == 0)
                    {
                        ButtonMap[x, y].BackColor = Color.Green;
                        Map[x, y] = 1;
                        break;
                    }
                }
            }
            if (ColorCount == 5)
            {
                while (true)
                {
                    int x = random.Next(1, 10);
                    int y = random.Next(1, 10);

                    if (Map[x, y] == 0)
                    {
                        ButtonMap[x, y].BackColor = Color.Green;
                        Map[x, y] = 1;
                        break;
                    }
                }
                while (true)
                {
                    int x = random.Next(1, 10);
                    int y = random.Next(1, 10);

                    if (Map[x, y] == 0)
                    {
                        ButtonMap[x, y].BackColor = Color.Pink;
                        Map[x, y] = 1;
                        break;
                    }
                }
            }
            if (ColorCount == 6)
            {
                while (true)
                {
                    int x = random.Next(1, 10);
                    int y = random.Next(1, 10);

                    if (Map[x, y] == 0)
                    {
                        ButtonMap[x, y].BackColor = Color.Green;
                        Map[x, y] = 1;
                        break;
                    }
                }
                while (true)
                {
                    int x = random.Next(1, 10);
                    int y = random.Next(1, 10);

                    if (Map[x, y] == 0)
                    {
                        ButtonMap[x, y].BackColor = Color.Pink;
                        Map[x, y] = 1;
                        break;
                    }
                }
                while (true)
                {
                    int x = random.Next(1, 10);
                    int y = random.Next(1, 10);

                    if (Map[x, y] == 0)
                    {
                        ButtonMap[x, y].BackColor = Color.Aqua;
                        Map[x, y] = 1;
                        break;
                    }
                }
            }
        }
        public void Die()
        {
            int k = 0;
            for(int i = 0; i < 11; i++)
            {
                for(int j = 0; j < 11; j++)
                {
                    if (ButtonMap[i, j].BackColor == Color.White)
                    {
                        k++;
                    }
                }
            }
            if (k <= 3)
            {
                label1.Text = "Вы проиграли.";

                File.WriteAllText(@"D:\Curs.txt", PlayerName + " Набрал " + score + " очков.");

            }
            else k = 0;
        }
        public void Relocation(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            int y1 = (pressedButton.Location.X / 40) ;
            int x1 = (pressedButton.Location.Y / 40) ;
            if (Bomb == 1)
            {
                ButtonMap[x1,y1].BackColor = Color.White;
                ButtonMap[x1+1, y1].BackColor = Color.White;
                ButtonMap[x1-1, y1].BackColor = Color.White;
                ButtonMap[x1, y1+1].BackColor = Color.White;
                ButtonMap[x1, y1-1].BackColor = Color.White;
                ButtonMap[x1 - 1, y1 + 1].BackColor = Color.White;
                ButtonMap[x1 - 1, y1-1].BackColor = Color.White;
                ButtonMap[x1 + 1, y1-1].BackColor = Color.White;
                ButtonMap[x1 + 1, y1 + 1].BackColor = Color.White;
                Map[x1, y1] = 0;
                Map[x1 + 1, y1] = 0;
                Map[x1 - 1, y1] = 0;
                Map[x1, y1 - 1] = 0;
                Map[x1 - 1, y1 + 1] = 0;
                Map[x1 - 1, y1 - 1] = 0;
                Map[x1 + 1, y1 - 1] = 0;
                Map[x1 + 1, y1 + 1] = 0;

                Bomb = 0;
            }
            if (pressedButton.BackColor == Color.Blue)
            {

                int x = (pressedButton.Location.X / 40) + 1;
                int y = (pressedButton.Location.Y / 40) + 1;
                int PointId = (y - 1) * 11 + x - 1;

                Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 0;
                give(ButtonMap, MatrixSm);
                DFS(PointId);
                pressedButton.BackColor = Color.White;
                prov = 1;
                check = 1;

            }
            if (pressedButton.BackColor == Color.Red)
            {
                int x = (pressedButton.Location.X / 40) + 1;
                int y = (pressedButton.Location.Y / 40) + 1;
                int PointId = (y - 1) * 11 + x - 1;


                Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 0;
                give(ButtonMap, MatrixSm);
                DFS(PointId);
                pressedButton.BackColor = Color.White;
                prov = 2;
                check = 1;

            }
            if (pressedButton.BackColor == Color.Yellow)
            {
                int x = (pressedButton.Location.X / 40) + 1;
                int y = (pressedButton.Location.Y / 40) + 1;
                int PointId = (y - 1) * 11 + x - 1;

                Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 0;
                give(ButtonMap, MatrixSm);
                DFS(PointId);
                pressedButton.BackColor = Color.White;
                prov = 3;
                check = 1;
            }
            if (pressedButton.BackColor == Color.Green)
            {
                int x = (pressedButton.Location.X / 40) + 1;
                int y = (pressedButton.Location.Y / 40) + 1;
                int PointId = (y - 1) * 11 + x - 1;

                Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 0;
                give(ButtonMap, MatrixSm);
                DFS(PointId);
                pressedButton.BackColor = Color.White;
                prov = 4;
                check = 1;
            }
            if (pressedButton.BackColor == Color.Pink)
            {
                int x = (pressedButton.Location.X / 40) + 1;
                int y = (pressedButton.Location.Y / 40) + 1;
                int PointId = (y - 1) * 11 + x - 1;

                Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 0;
                give(ButtonMap, MatrixSm);
                DFS(PointId);
                pressedButton.BackColor = Color.White;
                prov = 5;
                check = 1;
            }
            if (pressedButton.BackColor == Color.Aqua)
            {
                int x = (pressedButton.Location.X / 40) + 1;
                int y = (pressedButton.Location.Y / 40) + 1;
                int PointId = (y - 1) * 11 + x - 1;

                Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 0;
                give(ButtonMap, MatrixSm);
                DFS(PointId);
                pressedButton.BackColor = Color.White;
                prov = 6;
                check = 1;
            }
            if (check == 0)
            {
                int x = (pressedButton.Location.X / 40);
                int y = (pressedButton.Location.Y / 40);
                int PointId = y * 11 + x;
                if (visited[PointId] == 1)
                {

                    if (pressedButton.BackColor == Color.White && prov == 1)
                    {
                        Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 1;
                        pressedButton.BackColor = Color.Blue;
                        LineCheck(pressedButton, ButtonMap);
                        Generation();
                        Die();
                        for (int i = 0; i < 121; i++)
                        {
                            visited[i] = 0;
                        }


                    }
                    else if (pressedButton.BackColor == Color.White && prov == 2)
                    {
                        pressedButton.BackColor = Color.Red;

                        Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 1;
                        LineCheck(pressedButton, ButtonMap);
                        Generation();
                        Die();
                        for (int i = 0; i < 121; i++)
                        {
                            visited[i] = 0;
                        }


                    }
                    else if (pressedButton.BackColor == Color.White && prov == 3)
                    {
                        pressedButton.BackColor = Color.Yellow;
                        Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 1;
                        LineCheck(pressedButton, ButtonMap);
                        Generation();
                        Die();
                        for (int i = 0; i < 121; i++)
                        {
                            visited[i] = 0;

                        }

                    }
                    else if (pressedButton.BackColor == Color.White && prov == 4)
                    {
                        pressedButton.BackColor = Color.Green;
                        Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 1;
                        LineCheck(pressedButton, ButtonMap);
                        Generation();
                        Die();
                        for (int i = 0; i < 121; i++)
                        {
                            visited[i] = 0;

                        }

                    }
                    else if (pressedButton.BackColor == Color.White && prov == 5)
                    {
                        pressedButton.BackColor = Color.Pink;
                        Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 1;
                        LineCheck(pressedButton, ButtonMap);
                        Generation();
                        Die();
                        for (int i = 0; i < 121; i++)
                        {
                            visited[i] = 0;

                        }

                    }
                    else if (pressedButton.BackColor == Color.White && prov == 6)
                    {
                        pressedButton.BackColor = Color.Aqua;
                        Map[(pressedButton.Location.Y / 40), (pressedButton.Location.X / 40)] = 1;
                        LineCheck(pressedButton, ButtonMap);
                        Generation();
                        Die();
                        for (int i = 0; i < 121; i++)
                        {
                            visited[i] = 0;

                        }

                    }
                }


            }
            else check = 0;


        }


        public void LineCheck(Button Pressed, Button[,] array)
        {

            int y = Pressed.Location.Y / 40;
            int x = Pressed.Location.X / 40;
            int destroy = 0;
            
            for (int i = 0; i < 11; i++)
            {


                if (array[i, x].BackColor == Pressed.BackColor)
                {
                    destroy++;
                }
                else destroy = 0;


                if (destroy == 5)
                {
                    for (int k = i; k >= i - destroy; k--)
                    {
                        array[k, x].BackColor = Color.White;
                        Map[k, x] = 0;  
                    }
                    score =score+ 5;
                    label4.Text = Convert.ToString(score);

                }

            }

            for (int f = 0; f < 11; f++)
            {

                if (array[y, f].BackColor == Pressed.BackColor)
                {
                    destroy++;

                }
                else destroy = 0;


                if (destroy == 5)
                {
                    for (int m = f; m > f - destroy; m--)
                    {
                        array[y, m].BackColor = Color.White;
                        Map[y, m] = 0;
                    }
                    score =score+ 5;
                    label4.Text = Convert.ToString(score);

                }

            }
        }

        public void DFS(int a)
        {


            visited[a] = 1;

            for (int i = 0; i < 121; i++)
            {
                if (visited[i] == 0 & MatrixSm[a, i] == 1)
                {
                    if (ButtonMap[i / 11, i % 11].BackColor == Color.White)
                    {
                        visited[i] = 1;
                        DFS(i);
                    }
                }

            }
        }
        //велью 1
        public void give(Button[,] array, int[,] array2)
        {
            for (int j = 1; j < 10; j++)
            {
                for (int i = 1; i < 10; i++)
                {
                    array2[j * 11 + i, j * 11 + i] = 0;

                    if (array[j + 1, i].BackColor == Color.White)
                    {
                        int id = j * 11 + i;
                        array2[id, id + 11] = 1;

                    }

                    if (array[j, i + 1].BackColor == Color.White)
                    {
                        int id = j * 11 + i;
                        array2[id, id + 1] = 1;

                    }
                    if (array[j - 1, i].BackColor == Color.White)
                    {
                        int id = j * 11 + i;
                        array2[id, id - 11] = 1;

                    }
                    if (array[j, i - 1].BackColor == Color.White)
                    {
                        int id = j * 11 + i;
                        array2[id, id - 1] = 1;

                    }

                    for (int m = 0; m < 121; m++)
                    {
                        array2[0, m] = 0;
                        array2[m, 0] = 0;
                        array2[120, m] = 0;
                        array2[m, 120] = 0;

                    }
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {



            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * 40, i * 40);
                    button.BackColor = Color.White;
                    button.Size = new Size(40, 40);
                    button.Click += new EventHandler(Relocation);
                    this.Controls.Add(button);
                    ButtonMap[i, j] = button;


                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0 || i == 10 || j == 0 || j == 10)
                    {
                        Map[i, j] = 1;
                    }
                    else
                    {
                        Map[i, j] = 0;

                    }
                }
            }
            Generation();
            prov = 0;
            label2.Text = PlayerName;
            label6.Text = Convert.ToString(ColorCount);
            label4.Text = Convert.ToString(score);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             Bomb= 1;
        }
    }
}

