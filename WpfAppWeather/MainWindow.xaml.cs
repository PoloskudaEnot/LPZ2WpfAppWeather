using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using WpfAppWeather.Class;
using System.Drawing;

namespace WpfAppWeather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonEmptyCity_Click(object sender, RoutedEventArgs e)
        {
            try         //Обработчик возможных ошибок
            {
                WebRequest webRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + TextBoxCity.Text + "&APPID=b363071bedb71290a6543d31115dee59");      //Создает HTTP-запрос к API погоде, textboxCity-передаем город, APPID - личный ключ для работы с API
                webRequest.Method = "GET";      //Указываем тип запроса, GET - для получения данных
                webRequest.ContentType = "application/x-www-form-urlencoded";        //тип содержимого


                OpenWeather openWeather;        //Создаем объект для хранения данных о погоде. 

                WebResponse webResponse = webRequest.GetResponse();     //Отправка запроса и получение ответа от сервера
                using (Stream stream = webResponse.GetResponseStream())     //Управление ресурсами потока и его закрытие
                {
                    using (StreamReader streamReader = new StreamReader(stream))        //Чтение данных из потока
                    {
                        TextBlockResponse.Text = streamReader.ReadToEnd();      //Читает весь ответ и сохраняем JSON в TextBlockResponse
                    }
                }
                webResponse.Close();        //Закрытие соединение

                openWeather = JsonConvert.DeserializeObject<OpenWeather>(TextBlockResponse.Text);       //Преобразуем JSON строку в объект C# OpenWeather, строка JSON берется не на прямую,а из TextBlockResponse

                LabelClouds.Content = openWeather.clouds.All.ToString();        //В label выводим облачность
                LabelPressure.Content = openWeather.main.Pressure.ToString();       //В label выводим давление
                LabelSpeed.Content = openWeather.wind.Speed.ToString();         //В label выводим скорость ветра
                LabelTemp.Content = openWeather.main.TempCelsius.ToString();        //В label выводим температуру
                LabelTempMin.Content = openWeather.main.TempMin.ToString();     //В label выводим минимальную температуру
                LabelTexmpMax.Content = openWeather.main.TempMax.ToString();        //В label выводим максимальную температуру

                Uri uri = new Uri(openWeather.weather[0].Icon);     //Получаем URL иконки погоды из ответа
                ImageIconWeather.Source = new BitmapImage(uri);     //Устанавливаем иконку в элемент Image
            }
            catch (Exception ex)        //Объект содержащий информацию от ошибке
            {
                MessageBox.Show(ex.Message);        //Показываем сообщение пользователю об ошибкеИ
            }
            
        }
    }
}
