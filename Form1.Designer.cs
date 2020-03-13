
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cell[i, j] = new Cell(j, i);
                }
            }
            for (int i = 0; i < Bombs; i++)
            {
                var rnd = new Random();
                // while (cell[rnd.Next(0, 10), rnd.Next(0, 10)].IsBomb == true)
                // {
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                cell[y, x].IsBomb = true;
                if (y + 1 < 10 && cell[y + 1, x].IsBomb == false)
                {
                    cell[y + 1, x].Value++;
                }
                if (y - 1 >= 0 && cell[y - 1, x].IsBomb == false)
                {
                    cell[y - 1, x].Value++;
                }
                if (x + 1 < 10 && cell[y, x + 1].IsBomb == false)
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
                if (x - 1 >= 0 && y + 1 < 10 && cell[y + 1, x - 1].IsBomb == false)
                {
                    cell[y + 1, x - 1].Value++;
                }
                if (x + 1 < 10 && y - 1 >= 0 && cell[y - 1, x + 1].IsBomb == false)
                {
                    cell[y - 1, x + 1].Value++;
                }
                if (x + 1 < 10 && y + 1 < 10 && cell[y + 1, x + 1].IsBomb == false)
                {
                    cell[y + 1, x + 1].Value++;
                }
                //  }
                Thread.Sleep(20);

            }

            this.SuspendLayout();
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    this.cell[i, j].BackColor = System.Drawing.SystemColors.ActiveBorder;
                    this.cell[i, j].FlatAppearance.BorderSize = 0;
                    this.cell[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.cell[i, j].Location = new System.Drawing.Point(205 + j * 27, 74 + i * 27);
                    this.cell[i, j].Name = k.ToString();
                    this.cell[i, j].Size = new System.Drawing.Size(25, 25);
                    this.cell[i, j].TabIndex = 0;
                    this.cell[i, j].UseVisualStyleBackColor = false;
                    this.cell[i, j].Click += Field_Click;
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

        private void Field_Click(object sender, System.EventArgs e)
        {
            var choice = sender as Cell;
            choice.Pressed = true;

            if (choice.IsBomb)
            {
                choice.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
                choice.Click -= Field_Click;
                System.Windows.Forms.MessageBox.Show("Проиграл!");
            }
            else
            {
                choice.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

                if (choice.Value > 0)
                {
                    choice.ForeColor = Color.Red;

                    choice.Text = choice.Value.ToString();
                }
                if (choice.X + 1 < 10 && !cell[choice.Y, choice.X + 1].IsBomb && !cell[choice.Y, choice.X + 1].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y, choice.X + 1], e);
                }
                if (choice.X - 1 >= 0 && !cell[choice.Y, choice.X - 1].IsBomb && !cell[choice.Y, choice.X - 1].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y, choice.X - 1], e);
                }
                if (choice.Y + 1 < 10 && !cell[choice.Y + 1, choice.X].IsBomb && !cell[choice.Y + 1, choice.X].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y + 1, choice.X], e);
                }
                if (choice.Y - 1 >= 0 && !cell[choice.Y - 1, choice.X].IsBomb && !cell[choice.Y - 1, choice.X].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y - 1, choice.X], e);
                }
                if (choice.X + 1 < 10 && choice.Y + 1 < 10 && !cell[choice.Y + 1, choice.X + 1].IsBomb && !cell[choice.Y + 1, choice.X + 1].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y + 1, choice.X + 1], e);
                }
                if (choice.X + 1 < 10 && choice.Y - 1 >= 0 && !cell[choice.Y - 1, choice.X + 1].IsBomb && !cell[choice.Y - 1, choice.X + 1].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y - 1, choice.X + 1], e);
                }
                if (choice.X - 1 >= 0 && choice.Y + 1 < 10 && !cell[choice.Y + 1, choice.X - 1].IsBomb && !cell[choice.Y + 1, choice.X - 1].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y + 1, choice.X - 1], e);
                }
                if (choice.X - 1 >= 0 && choice.Y - 1 >= 0 && !cell[choice.Y - 1, choice.X - 1].IsBomb && !cell[choice.Y - 1, choice.X - 1].Pressed && choice.Value == 0)
                {
                    Field_Click(cell[choice.Y - 1, choice.X - 1], e);
                }
            }
            choice.Enabled = false;
        }

        #endregion


        private Cell[,] cell = new Cell[10, 10];
        private const int Bombs = 10;
    }
}

