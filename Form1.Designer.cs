
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Sapper
{
    partial class Form1
    {



        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool Win()
        {
            bool t = true;
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (!cell[i, j].IsBomb && cell[i, j].Enabled)
                        t = false;

            return t;
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    cell[i, j] = new Cell(j, i);
                }
            }
            for (int i = 0; i < Bombs; i++)
            {
                var rnd = new Random();
                // while (cell[rnd.Next(0, 10), rnd.Next(0, 10)].IsBomb == true)
                // {
                int x = rnd.Next(0, Width);
                int y = rnd.Next(0, Height);
                if (cell[y, x].IsBomb != true)
                {
                    cell[y, x].IsBomb = true;
                    if (y + 1 < Height && cell[y + 1, x].IsBomb == false)
                    {
                        cell[y + 1, x].Value++;
                    }
                    if (y - 1 >= 0 && cell[y - 1, x].IsBomb == false)
                    {
                        cell[y - 1, x].Value++;
                    }
                    if (x + 1 < Width && cell[y, x + 1].IsBomb == false)
                    {
                        cell[y, x + 1].Value++;
                    }
                    if (x - 1 >= 0 && cell[y, x - 1].IsBomb == false)
                    {
                        cell[y, x - 1].Value++;
                    }
                    if (x - 1 >= 0 && y - 1 >= 0 && cell[y - 1, x - 1].IsBomb == false)
                    {
                        cell[y - 1, x - 1].Value++;
                    }
                    if (x - 1 >= 0 && y + 1 < Height && cell[y + 1, x - 1].IsBomb == false)
                    {
                        cell[y + 1, x - 1].Value++;
                    }
                    if (x + 1 < Width && y - 1 >= 0 && cell[y - 1, x + 1].IsBomb == false)
                    {
                        cell[y - 1, x + 1].Value++;
                    }
                    if (x + 1 < Width && y + 1 < Height && cell[y + 1, x + 1].IsBomb == false)
                    {
                        cell[y + 1, x + 1].Value++;
                    }
                }
                Thread.Sleep(20);

            }

            this.SuspendLayout();
            int k = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    //this.cell[i, j].ForeColor = Color.Red;
                    this.cell[i, j].BackColor = System.Drawing.SystemColors.ActiveBorder;
                    this.cell[i, j].FlatAppearance.BorderSize = 0;
                    this.cell[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.cell[i, j].Location = new System.Drawing.Point(205 + j * (ButtonSize + 2), 74 + i * (ButtonSize + 2));
                    this.cell[i, j].Name = k.ToString();
                    this.cell[i, j].Size = new System.Drawing.Size(ButtonSize, ButtonSize);
                    this.cell[i, j].TabIndex = k;
                    this.cell[i, j].UseVisualStyleBackColor = false;
                    this.cell[i, j].MouseUp += Field_Click;

                    k++;
                }
            }

            //// Form1

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            foreach (var c in cell)
            {
                this.Controls.Add(c);
            }
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private void Field_Click(object sender, MouseEventArgs e)
        {
            var choice = sender as Cell;
            var ee = e as MouseEventArgs;
            if (ee.Button == MouseButtons.Left)
            {

                if (!choice.Flag)
                {
                    choice.Enabled = false;

                    if (choice.IsBomb)
                    {
                        choice.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
                        choice.MouseClick -= Field_Click;
                        System.Windows.Forms.MessageBox.Show("Проиграл!");
                        new Form2().Show();
                        this.Close();
                        

                        
                    }
                    else
                    {

                        choice.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

                        if (choice.Value > 0)
                        {
                            choice.ForeColor = Color.Red;


                            choice.Text = choice.Value.ToString();
                            choice.Invalidate();
                        }
                        if (choice.X + 1 < Width && !cell[choice.Y, choice.X + 1].IsBomb && cell[choice.Y, choice.X + 1].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y, choice.X + 1], e);
                        }
                        if (choice.X - 1 >= 0 && !cell[choice.Y, choice.X - 1].IsBomb && cell[choice.Y, choice.X - 1].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y, choice.X - 1], e);
                        }
                        if (choice.Y + 1 < Height && !cell[choice.Y + 1, choice.X].IsBomb && cell[choice.Y + 1, choice.X].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y + 1, choice.X], e);
                        }
                        if (choice.Y - 1 >= 0 && !cell[choice.Y - 1, choice.X].IsBomb && cell[choice.Y - 1, choice.X].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y - 1, choice.X], e);
                        }
                        if (choice.X + 1 < Width && choice.Y + 1 < Height && !cell[choice.Y + 1, choice.X + 1].IsBomb && cell[choice.Y + 1, choice.X + 1].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y + 1, choice.X + 1], e);
                        }
                        if (choice.X + 1 < Width && choice.Y - 1 >= 0 && !cell[choice.Y - 1, choice.X + 1].IsBomb && cell[choice.Y - 1, choice.X + 1].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y - 1, choice.X + 1], e);
                        }
                        if (choice.X - 1 >= 0 && choice.Y + 1 < Height && !cell[choice.Y + 1, choice.X - 1].IsBomb && cell[choice.Y + 1, choice.X - 1].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y + 1, choice.X - 1], e);
                        }
                        if (choice.X - 1 >= 0 && choice.Y - 1 >= 0 && !cell[choice.Y - 1, choice.X - 1].IsBomb && cell[choice.Y - 1, choice.X - 1].Enabled && choice.Value == 0)
                        {
                            Field_Click(cell[choice.Y - 1, choice.X - 1], e);
                        }
                    }
                }

            }
            if (ee.Button == MouseButtons.Right)
            {
                choice.ToFlag();
            }
            if (Win())
            {
                MessageBox.Show("Вы победили!");
                this.Close();
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        #endregion
        static int ButtonSize = 25;
        static int Width = 50;
        static int Height = 10;
        private Cell[,] cell = new Cell[Height, Width];
        private const int Bombs = 20;
    }
}

