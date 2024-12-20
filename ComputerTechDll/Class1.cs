using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComputerTechDll
{
    public class CaptchaGenerator
    {
        public (Bitmap captchaImage, string captchaText) GenerateCaptcha()
        {
            Random random = new Random();
            const string chars = "abcdefghirstuvwxyzABCDEFGHRSTUVWXYZ0123456789";
            string currentCapcha = new string(Enumerable.Repeat(chars, 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            Bitmap capchaImage = new Bitmap(180, 80); // Устанавливаем размер изображения
            using (Graphics g = Graphics.FromImage(capchaImage))
            {
                g.Clear(Color.White);

                // Добавление шума: линии и точки
                for (int i = 0; i < 40; i++) // Генерация случайных линий
                {
                    g.DrawLine(new Pen(Color.LightGray, 2), random.Next(0, 180), random.Next(0, 80), random.Next(0, 180), random.Next(0, 80));
                }

                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                {
                    // Рисуем символы капчи с наклоном и случайным смещением
                    for (int i = 0; i < currentCapcha.Length; i++)
                    {
                        float angle = random.Next(-4, 4); // Угол наклона
                        g.RotateTransform(angle);
                        g.DrawString(currentCapcha[i].ToString(), font, Brushes.Black, new PointF(10 + (i * 40) + random.Next(-5, 5), 20 + random.Next(-5, 5)));
                        g.RotateTransform(-angle); // Возвращаем графику в исходное состояние
                    }
                }
            }

            return (capchaImage, currentCapcha);
        }
    }
}