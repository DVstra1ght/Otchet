using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Объявляем все необходимые элементы управления
        private Button btnSave;         // Кнопка для сохранения настроек
        private Button btnChooseColor;  // Кнопка для выбора цвета фона
        private TextBox txtUserInput;   // Поле для ввода текста
        private ColorDialog colorDialog1; // Диалог выбора цвета

        public Form1()
        {
            InitializeComponent();

            // --- НАСТРОЙКА СВОЙСТВ ФОРМЫ ---
            this.Text = "Настройка приложения"; // Заголовок окна
            this.Size = new Size(350, 250);        // Размер окна (ширина, высота)
            this.StartPosition = FormStartPosition.CenterScreen; // По центру экрана

            // --- ИНИЦИАЛИЗАЦИЯ И НАСТРОЙКА ЭЛЕМЕНТОВ ---

            // 1. Текстовое поле (TextBox)
            txtUserInput = new TextBox();
            txtUserInput.Location = new Point(30, 30);
            txtUserInput.Size = new Size(270, 25);
            txtUserInput.PlaceholderText = "Введите ваш текст здесь..."; // Подсказка внутри поля

            // 2. Диалоговое окно выбора цвета (ColorDialog)
            colorDialog1 = new ColorDialog();

            // 3. Кнопка выбора цвета
            btnChooseColor = new Button();
            btnChooseColor.Text = "Выбрать цвет фона";
            btnChooseColor.Location = new Point(30, 80);
            btnChooseColor.Size = new Size(270, 30);
            btnChooseColor.Click += new EventHandler(btnChooseColor_Click); // Привязка события

            // 4. Кнопка сохранения настроек (Button)
            btnSave = new Button();
            btnSave.Text = "Сохранить настройки";
            btnSave.Location = new Point(30, 140);
            btnSave.Size = new Size(270, 35);
            btnSave.Font = new Font(btnSave.Font, FontStyle.Bold); // Делаем текст жирным       
            btnSave.Click += new EventHandler(btnSave_Click);       // Привязка события

            // --- ДОБАВЛЕНИЕ ЭЛЕМЕНТОВ НА ФОРМУ ---
            this.Controls.Add(txtUserInput);
            this.Controls.Add(btnChooseColor);
            this.Controls.Add(btnSave);
        }

        // Обработчик нажатия на кнопку "Выбрать цвет фона"
        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            // Открываем окно выбора цвета. Если пользователь нажал "ОК" — меняем цвет формы
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        // Обработчик нажатия на кнопку "Сохранить настройки"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Выводим сообщение о том, что текст успешно сохранен
            string userText = txtUserInput.Text;
            MessageBox.Show($"Настройки успешно сохранены!\nВаш текст: \"{userText}\"",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}