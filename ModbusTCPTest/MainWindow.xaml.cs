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
using System.Windows.Threading;
using EasyModbus;

namespace ModbusTCPTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModbusClient modbusClient;
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ComboBoxItem selectItem = (ComboBoxItem)(comboIpConnect.SelectedValue);
                string ipConnect = (string)(selectItem.Content);
                modbusClient = new EasyModbus.ModbusClient(ipConnect, 502);
                modbusClient.Connect();
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(500);

                //var timer_Coil = new DispatcherTimer();
                //timer_Coil.Interval = TimeSpan.FromMilliseconds(100);

                //timer.Tick += ReadDiscret141;
                //timer.Tick += ReadDiscret231;
                //timer.Tick += ReadDiscret161;
                //timer.Tick += ReadDiscret251;
                timer.Tick += RunAllAsync;
                //timer.Tick += ReadCoil161;
                //timer.Tick += ReadCoil251;
                //timer.Tick += ReadCoil231;
                //timer.Tick += ReadCoi141;
                 timer.Start();
                //RunAllAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errrorrr");

            }
        }

        private void RunAllAsync(object sender,EventArgs e)
        {
            
            var result= Task.Run(() =>
            {
                ReadDiscret141();
                ReadDiscret231();
                ReadDiscret161();
            });

            Task.WaitAll(result);
        }

        private async Task<bool[]> ReturnInputDiscretasync141(int adress, ModbusClient modbusClient)
        {
            return await Task.Run(() =>
            {
                return modbusClient.ReadDiscreteInputs(adress, 10);
            }
            );
        }

        private  async void  ReadDiscret141()
        {
            //var readCoilD141_1 =  modbusClient.ReadDiscreteInputs(374, 10);
            var readCoilD141_1 = await ReturnInputDiscretasync141(1, modbusClient);

            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    if (readCoilD141_1[9])
                    {
                        ellipseB171.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD141_1[7])
                    {
                        ellipseB171_Copy.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD141_1[6])
                    {
                        ellipseB171_Copy1.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy1.Fill = new SolidColorBrush(Colors.Black);
                    }



                    if (readCoilD141_1[1])
                    {
                        ellipseB171_Copy2.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy2.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD141_1[0])
                    {
                        ellipseB171_Copy3.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy3.Fill = new SolidColorBrush(Colors.Black);
                    }
                });
                //Task.Delay(500);
            });
        }

        private async Task<bool[]> ReturnInputDiscretasync231(int adress, ModbusClient modbusClient)
        {

            return await Task.Run(() =>

            {
                return modbusClient.ReadDiscreteInputs(adress, 10);

            }
            );
        }

        private async void ReadDiscret231()
        {
            //var readCoilD231 = modbusClient.ReadDiscreteInputs(452, 10);

            var readCoilD231 = await ReturnInputDiscretasync231(15, modbusClient);
            await Task.Run(() =>
            {

                Dispatcher.Invoke(() =>
                {
                    if (readCoilD231[9])
                    {
                        ellipseB171_Copy5.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy5.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD231[8])
                    {
                        ellipseB171_Copy6.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy6.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD231[3])
                    {
                        ellipseB171_Copy7.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy7.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD231[2])
                    {
                        ellipseB171_Copy8.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy8.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD231[1])
                    {
                        ellipseB171_Copy9.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy9.Fill = new SolidColorBrush(Colors.Black);
                    }

                    if (readCoilD231[0])
                    {
                        ellipseB171_Copy10.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        ellipseB171_Copy10.Fill = new SolidColorBrush(Colors.Black);
                    }
                });
                //Task.Delay(500);
            });
        }

        private async Task<bool[]> ReturnInputDiscretasync161(int adress, ModbusClient modbusClient)
        {

            return await Task.Run(() =>

            {
                return modbusClient.ReadDiscreteInputs(adress, 11);

            }
            );
        }
        
        private async void ReadDiscret161()
        {
            //var readCoilD161 = modbusClient.ReadDiscreteInputs(384, 11);

            var readCoilD161 = await ReturnInputDiscretasync161(25, modbusClient);
            await Task.Run(() =>
            {

                Dispatcher.Invoke(() =>
            {

                if (readCoilD161[0])
                {
                    ellipseB171_Copy11.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy11.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[1])
                {
                    ellipseB171_Copy12.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy12.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[3])
                {
                    ellipseB171_Copy13.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy13.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[4])
                {
                    ellipseB171_Copy14.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy14.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[5])
                {
                    ellipseB171_Copy15.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy15.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[6])
                {
                    ellipseB171_Copy16.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy16.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[7])
                {
                    ellipseB171_Copy17.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy17.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[8])
                {
                    ellipseB171_Copy18.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy18.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[9])
                {
                    ellipseB171_Copy19.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy19.Fill = new SolidColorBrush(Colors.Black);
                }

                if (readCoilD161[10])
                {
                    ellipseB171_Copy20.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ellipseB171_Copy20.Fill = new SolidColorBrush(Colors.Black);
                }
            });
            });
        }

        #region
        //private async Task<bool[]> ReturnInputDiscretasync251(int adress, ModbusClient modbusClient)
        //{

        //    return await Task.Run(() =>

        //    {
        //        return modbusClient.ReadDiscreteInputs(adress, 4);

        //    }
        //    );
        //}

        //private async void ReadDiscret251(object sender, EventArgs e)
        //{
        //    //var readCoilD251 = modbusClient.ReadDiscreteInputs(464, 4);

        //    var readCoilD251 = await ReturnInputDiscretasync251(464, modbusClient);

        //    if (readCoilD251[0])
        //    {
        //        ellipseB171_Copy21.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy21.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoilD251[1])
        //    {
        //        ellipseB171_Copy22.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy22.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoilD251[2])
        //    {
        //        ellipseB171_Copy23.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy23.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoilD251[3])
        //    {
        //        ellipseB171_Copy24.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy24.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //}

        //private async Task<bool[]> ReturnCoilAsync161(int adress, ModbusClient modbusClient)
        //{

        //    return await Task.Run(() =>

        //    {
        //        return modbusClient.ReadCoils(adress, 13);

        //    }
        //    );
        //}

        //private async void ReadCoil161(object sender, EventArgs e)
        //{
        //    //var readCoil161 = modbusClient.ReadCoils(387, 13);

        //    var readCoil161 = await ReturnCoilAsync161(387, modbusClient);

        //    if (readCoil161[0])
        //    {
        //        ellipseB171_Copy37.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy37.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil161[1])
        //    {
        //        ellipseB171_Copy36.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy36.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil161[2])
        //    {
        //        ellipseB171_Copy35.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy35.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil161[3])
        //    {
        //        ellipseB171_Copy34.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy34.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil161[4])
        //    {
        //        ellipseB171_Copy33.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy33.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil161[5])
        //    {
        //        ellipseB171_Copy32.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy32.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil161[6])
        //    {
        //        ellipseB171_Copy31.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy31.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil161[7])
        //    {
        //        ellipseB171_Copy30.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy30.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil161[8])
        //    {
        //        ellipseB171_Copy29.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy29.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil161[9])
        //    {
        //        ellipseB171_Copy28.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy28.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil161[10])
        //    {
        //        ellipseB171_Copy27.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy27.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil161[11])
        //    {
        //        ellipseB171_Copy26.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy26.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil161[12])
        //    {
        //        ellipseB171_Copy25.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy25.Fill = new SolidColorBrush(Colors.Black);
        //    }


        //}

        //private async Task<bool[]> ReturnCoilAsync251(int adress, ModbusClient modbusClient)
        //{

        //    return await Task.Run(() =>

        //    {
        //        return modbusClient.ReadCoils(adress, 4);

        //    }
        //    );
        //}

        //private async void ReadCoil251(object sender, EventArgs e)
        //{
        //    //var readCoil251 = modbusClient.ReadCoils(472, 4);

        //    var readCoil251 = await ReturnCoilAsync251(472, modbusClient);

        //    if (readCoil251[0])
        //    {
        //        ellipseB171_Copy43.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy43.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil251[1])
        //    {
        //        ellipseB171_Copy42.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy42.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil251[2])
        //    {
        //        ellipseB171_Copy41.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy41.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil251[3])
        //    {
        //        ellipseB171_Copy40.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy40.Fill = new SolidColorBrush(Colors.Black);
        //    }



        //}

        //private async Task<bool[]> ReturnCoilAsync231(int adress, ModbusClient modbusClient)
        //{

        //    return await Task.Run(() =>

        //    {
        //        return modbusClient.ReadCoils(adress, 12);

        //    }
        //    );
        //}

        //private async void ReadCoil231(object sender, EventArgs e)
        //{
        //    //var readCoil231 = modbusClient.ReadCoils(450, 12);

        //    var readCoil231 = await ReturnCoilAsync231(450, modbusClient);

        //    if (readCoil231[0])
        //    {
        //        ellipseB171_Copy44.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy44.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil231[1])
        //    {
        //        ellipseB171_Copy45.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy45.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil231[2])
        //    {
        //        ellipseB171_Copy46.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy46.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil231[3])
        //    {
        //        ellipseB171_Copy47.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy47.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil231[4])
        //    {
        //        ellipseB171_Copy48.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy48.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil231[5])
        //    {
        //        ellipseB171_Copy49.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy49.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil231[10])          /// проверить 313
        //    {
        //        ellipseB171_Copy50.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy50.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil231[11])  /// проверить 314
        //    {
        //        ellipseB171_Copy51.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy51.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //}

        //private async Task<bool[]> ReturnCoilAsync141(int adress, ModbusClient modbusClient)
        //{

        //    return await Task.Run(() =>

        //    {
        //        return modbusClient.ReadCoils(adress, 12);

        //    }
        //    );
        //}

        //private async void ReadCoi141(object sender, EventArgs e)
        //{
        //    //var readCoil141 = modbusClient.ReadCoils(372, 12);

        //    var readCoil141 = await ReturnCoilAsync141(372, modbusClient);

        //    if (readCoil141[0])
        //    {
        //        ellipseB171_Copy52.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy52.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil141[1])
        //    {
        //        ellipseB171_Copy53.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy53.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil141[8])
        //    {
        //        ellipseB171_Copy58.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy58.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //    if (readCoil141[9])
        //    {
        //        ellipseB171_Copy57.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy57.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil141[10])
        //    {
        //        ellipseB171_Copy59.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy59.Fill = new SolidColorBrush(Colors.Black);
        //    }
        //    if (readCoil141[11])
        //    {
        //        ellipseB171_Copy60.Fill = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        ellipseB171_Copy60.Fill = new SolidColorBrush(Colors.Black);
        //    }

        //}
        #endregion

        /// <summary>
        /// начало отработки кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            modbusClient.Disconnect();
        }

        private void btnSchema_Click(object sender, RoutedEventArgs e)
        {
            winDiagnost winDiagnost = new winDiagnost();
            winDiagnost.Show();
        }

        private void Error_Click(object sender, RoutedEventArgs e)
        {
            Error_windows error_Windows = new Error_windows();
            
            error_Windows.Show();
        }
    }
}
