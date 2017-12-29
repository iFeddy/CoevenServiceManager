using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cvnServiceManager.Properties;
using System.ServiceProcess;
using System.Globalization;
using System.Net.Mail;
using System.Diagnostics;
using System.IO;

namespace cvnServiceManager
{
    public partial class cvnserviceController : Form
    {
        string[] servicesNames = {
                                     "AESIRGAMES_OdinRestServer",
                                     "PG_AccountLogDB_Server",
                                     "PG_Login_Server",
                                     "PG_World_Manager_Server",
                                     "PG_Char_DB",
                                     "PG_GameLog_DB",
                                     "PG_Zone_00",
                                     "PG_Zone_01",
                                     "PG_Zone_02",
                                     "PG_Zone_03",
                                     //TestServer
                                     "w0_World_Manager",
                                     "w0_Char_DB",
                                     "w0_GameLog_DB",

                                     "w0_Zone_00",
                                     "w0_Zone_01",
                                     "w0_Zone_02",
                                     "w0_Zone_03",
                                 };

        public cvnserviceController()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            checkerService.Start();
            isConfigOn = 0;
            this.Width = 705;           
        }

        private void checkServiceStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            returnServiceStatus();
        }

        private void returnServiceStatus()
        {
            for (int i = 0; i <= servicesNames.Length - 1; i++)
            {
                returnServiceStatus(servicesNames[i]);
            }
        }

        private void returnServiceStatus(string p)
        {
            #region xelionOnline
            if (p == "AESIRGAMES_OdinRestServer")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot01.Image = Resources.bullet_green;
                            statusLabel01.Text = "Online";
                            statusLabel01.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot01.Image = Resources.bullet_red;
                            statusLabel01.Text = "Offline"; EnviarReporte();
                            statusLabel01.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot01.Image = Resources.bullet_red;
                            statusLabel01.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot01.Image = Resources.bullet_red;
                            statusLabel01.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot01.Image = Resources.bullet_red;
                            statusLabel01.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot01.Image = Resources.bullet_white;
                            statusLabel01.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot01.Image = Resources.bullet_white;
                    statusLabel01.Text = "Servicio No Instalado";
                }
            }
            if (p == "PG_AccountLogDB_Server")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot02.Image = Resources.bullet_green;
                            statusLabel02.Text = "Online";
                            statusLabel02.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot02.Image = Resources.bullet_red;
                            statusLabel02.Text = "Offline"; EnviarReporte();
                            statusLabel02.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot02.Image = Resources.bullet_red;
                            statusLabel02.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot02.Image = Resources.bullet_red;
                            statusLabel02.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot02.Image = Resources.bullet_red;
                            statusLabel02.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot02.Image = Resources.bullet_white;
                            statusLabel02.Text = "Error Buscando";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    statusDot02.Image = Resources.bullet_white;
                    statusLabel02.Text = "Servicio No Instalado";
                }
            }

            if (p == "PG_Login_Server")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot03.Image = Resources.bullet_green;
                            statusLabel03.Text = "Online";
                            statusLabel03.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot03.Image = Resources.bullet_red;
                            statusLabel03.Text = "Offline"; EnviarReporte();
                            statusLabel03.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot03.Image = Resources.bullet_red;
                            statusLabel03.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot03.Image = Resources.bullet_red;
                            statusLabel03.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot03.Image = Resources.bullet_red;
                            statusLabel03.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot03.Image = Resources.bullet_white;
                            statusLabel03.Text = "Error Buscando";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    statusDot03.Image = Resources.bullet_white;
                    statusLabel03.Text = "Servicio No Instalado";
                }
            }

            if (p == "PG_World_Manager_Server")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot04.Image = Resources.bullet_green;
                            statusLabel04.Text = "Online";
                            statusLabel04.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot04.Image = Resources.bullet_red;
                            statusLabel04.Text = "Offline";
                            sc.Start();
                            statusLabel04.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot04.Image = Resources.bullet_red;
                            statusLabel04.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot04.Image = Resources.bullet_red;
                            statusLabel04.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot04.Image = Resources.bullet_red;
                            statusLabel04.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot04.Image = Resources.bullet_white;
                            statusLabel04.Text = "Error Buscando";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    statusDot04.Image = Resources.bullet_white;
                    statusLabel04.Text = "Servicio No Instalado";
                }
            }

            if (p == "PG_Char_DB")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot05.Image = Resources.bullet_green;
                            statusLabel05.Text = "Online";
                            statusLabel05.ForeColor = Color.Yellow;

                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot05.Image = Resources.bullet_red;
                            statusLabel05.Text = "Offline"; EnviarReporte();
                            statusLabel05.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot05.Image = Resources.bullet_red;
                            statusLabel05.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot05.Image = Resources.bullet_red;
                            statusLabel05.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot05.Image = Resources.bullet_red;
                            statusLabel05.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot05.Image = Resources.bullet_white;
                            statusLabel05.Text = "Error Buscando";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    statusDot05.Image = Resources.bullet_white;
                    statusLabel05.Text = "Servicio No Instalado";
                }
            }

            if (p == "PG_GameLog_DB")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot06.Image = Resources.bullet_green;
                            statusLabel06.Text = "Online";
                            statusLabel06.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot06.Image = Resources.bullet_red;
                            statusLabel06.Text = "Offline"; EnviarReporte();
                            statusLabel06.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot06.Image = Resources.bullet_red;
                            statusLabel06.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot06.Image = Resources.bullet_red;
                            statusLabel06.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot06.Image = Resources.bullet_red;
                            statusLabel06.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot06.Image = Resources.bullet_white;
                            statusLabel06.Text = "Error Buscando";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    statusDot06.Image = Resources.bullet_white;
                    statusLabel06.Text = "Servicio No Instalado";
                }
            }

            //Inicio IF
            if (p == "PG_Zone_00")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot07.Image = Resources.bullet_green;
                            statusLabel07.Text = "Online";
                            statusLabel07.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot07.Image = Resources.bullet_red;
                            statusLabel07.Text = "Offline"; EnviarReporte();
                            statusLabel07.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot07.Image = Resources.bullet_red;
                            statusLabel07.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot07.Image = Resources.bullet_red;
                            statusLabel07.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot07.Image = Resources.bullet_red;
                            statusLabel07.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot07.Image = Resources.bullet_white;
                            statusLabel07.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot07.Image = Resources.bullet_white;
                    statusLabel07.Text = "Servicio No Instalado";
                }
            }
            //Fin IF
            //Inicio IF
            if (p == "PG_Zone_01")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot08.Image = Resources.bullet_green;
                            statusLabel08.Text = "Online";
                            statusLabel08.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot08.Image = Resources.bullet_red;
                            statusLabel08.Text = "Offline"; EnviarReporte();
                            statusLabel08.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot08.Image = Resources.bullet_red;
                            statusLabel08.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot08.Image = Resources.bullet_red;
                            statusLabel08.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot08.Image = Resources.bullet_red;
                            statusLabel08.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot08.Image = Resources.bullet_white;
                            statusLabel08.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot08.Image = Resources.bullet_white;
                    statusLabel08.Text = "Servicio No Instalado";
                }
            }
            //Fin IF
            //Inicio IF
            if (p == "PG_Zone_02")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot09.Image = Resources.bullet_green;
                            statusLabel09.Text = "Online";
                            statusLabel09.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot09.Image = Resources.bullet_red;
                            statusLabel09.Text = "Offline"; EnviarReporte();
                            statusLabel09.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot09.Image = Resources.bullet_red;
                            statusLabel09.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot09.Image = Resources.bullet_red;
                            statusLabel09.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot09.Image = Resources.bullet_red;
                            statusLabel09.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot09.Image = Resources.bullet_white;
                            statusLabel09.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot09.Image = Resources.bullet_white;
                    statusLabel09.Text = "Servicio No Instalado";
                }
            }
            //Fin IF
            //Inicio IF
            if (p == "PG_Zone_03")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot10.Image = Resources.bullet_green;
                            statusLabel10.Text = "Online";
                            statusLabel10.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "Offline"; EnviarReporte();
                            statusLabel10.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot10.Image = Resources.bullet_white;
                            statusLabel10.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot10.Image = Resources.bullet_white;
                    statusLabel10.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            //Inicio IF
            if (p == "PG_Zone_03")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot10.Image = Resources.bullet_green;
                            statusLabel10.Text = "Online";
                            statusLabel10.ForeColor = Color.Yellow;
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "Offline"; EnviarReporte();
                            statusLabel10.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot10.Image = Resources.bullet_red;
                            statusLabel10.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot10.Image = Resources.bullet_white;
                            statusLabel10.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot10.Image = Resources.bullet_white;
                    statusLabel10.Text = "Servicio No Instalado";
                }
            }
            //Fin IF
            #endregion
            
            #region testyServer
 
            //Inicio IF
            if (p == "w0_World_Manager")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot11.Image = Resources.bullet_green;
                            statusLabel11.Text = "Online";
                            statusLabel11.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot11.Image = Resources.bullet_red;
                            statusLabel11.Text = "Offline";
                            statusLabel11.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot11.Image = Resources.bullet_red;
                            statusLabel11.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot11.Image = Resources.bullet_red;
                            statusLabel11.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot11.Image = Resources.bullet_red;
                            statusLabel11.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot11.Image = Resources.bullet_white;
                            statusLabel11.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot11.Image = Resources.bullet_white;
                    statusLabel11.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            //Inicio IF
            if (p == "w0_Char_DB")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot12.Image = Resources.bullet_green;
                            statusLabel12.Text = "Online";
                            statusLabel12.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot12.Image = Resources.bullet_red;
                            statusLabel12.Text = "Offline";
                            statusLabel12.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot12.Image = Resources.bullet_red;
                            statusLabel12.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot12.Image = Resources.bullet_red;
                            statusLabel12.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot12.Image = Resources.bullet_red;
                            statusLabel12.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot12.Image = Resources.bullet_white;
                            statusLabel12.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot12.Image = Resources.bullet_white;
                    statusLabel12.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            //Inicio IF
            if (p == "w0_GameLog_DB")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot13.Image = Resources.bullet_green;
                            statusLabel13.Text = "Online";
                            statusLabel13.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot13.Image = Resources.bullet_red;
                            statusLabel13.Text = "Offline";
                            statusLabel13.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot13.Image = Resources.bullet_red;
                            statusLabel13.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot13.Image = Resources.bullet_red;
                            statusLabel13.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot13.Image = Resources.bullet_red;
                            statusLabel13.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot13.Image = Resources.bullet_white;
                            statusLabel13.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot13.Image = Resources.bullet_white;
                    statusLabel13.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            //Inicio IF
            if (p == "w0_Zone_00")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot14.Image = Resources.bullet_green;
                            statusLabel14.Text = "Online";
                            statusLabel14.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot14.Image = Resources.bullet_red;
                            statusLabel14.Text = "Offline";
                            statusLabel14.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot14.Image = Resources.bullet_red;
                            statusLabel14.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot14.Image = Resources.bullet_red;
                            statusLabel14.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot14.Image = Resources.bullet_red;
                            statusLabel14.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot14.Image = Resources.bullet_white;
                            statusLabel14.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot14.Image = Resources.bullet_white;
                    statusLabel14.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            //Inicio IF
            if (p == "w0_Zone_01")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot15.Image = Resources.bullet_green;
                            statusLabel15.Text = "Online";
                            statusLabel15.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot15.Image = Resources.bullet_red;
                            statusLabel15.Text = "Offline";
                            statusLabel15.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot15.Image = Resources.bullet_red;
                            statusLabel15.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot15.Image = Resources.bullet_red;
                            statusLabel15.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot15.Image = Resources.bullet_red;
                            statusLabel15.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot15.Image = Resources.bullet_white;
                            statusLabel15.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot15.Image = Resources.bullet_white;
                    statusLabel15.Text = "Servicio No Instalado";
                }
            }
            //Fin IF
            //Inicio IF
            if (p == "w0_Zone_02")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot16.Image = Resources.bullet_green;
                            statusLabel16.Text = "Online";
                            statusLabel16.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot16.Image = Resources.bullet_red;
                            statusLabel16.Text = "Offline";
                            statusLabel16.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot16.Image = Resources.bullet_red;
                            statusLabel16.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot16.Image = Resources.bullet_red;
                            statusLabel16.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot16.Image = Resources.bullet_red;
                            statusLabel16.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot16.Image = Resources.bullet_white;
                            statusLabel16.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot16.Image = Resources.bullet_white;
                    statusLabel16.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            //Inicio IF
            if (p == "w0_Zone_02")
            {
                try
                {
                    ServiceController sc = new ServiceController(p);

                    switch (sc.Status)
                    {
                        case ServiceControllerStatus.Running:
                            statusDot17.Image = Resources.bullet_green;
                            statusLabel17.Text = "Online";
                            statusLabel17.ForeColor = Color.Yellow;
                            
                            break;
                        case ServiceControllerStatus.Stopped:
                            statusDot17.Image = Resources.bullet_red;
                            statusLabel17.Text = "Offline";
                            statusLabel17.ForeColor = Color.LightCoral;
                            break;
                        case ServiceControllerStatus.Paused:
                            statusDot17.Image = Resources.bullet_red;
                            statusLabel17.Text = "En Pausa";
                            break;
                        case ServiceControllerStatus.StopPending:
                            statusDot17.Image = Resources.bullet_red;
                            statusLabel17.Text = "Cerrando Servidor";
                            break;
                        case ServiceControllerStatus.StartPending:
                            statusDot17.Image = Resources.bullet_red;
                            statusLabel17.Text = "Empezando Servidor";
                            break;
                        default:
                            statusDot17.Image = Resources.bullet_white;
                            statusLabel17.Text = "Error Buscando";
                            break;
                    }

                }
                catch (Exception ex)
                {
                    statusDot17.Image = Resources.bullet_white;
                    statusLabel17.Text = "Servicio No Instalado";
                }
            }
            //Fin IF

            #endregion
        }

   
        private void checkServiceStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string date = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            statusLabel.Text = "Servidor revisado por ultima vez a las " + date;
        }

        private void checkerService_Tick(object sender, EventArgs e)
        {
            checkServiceStatus.RunWorkerAsync();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
            }

        }

        private void cvnserviceController_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

        }

        private void startTestServer_Click(object sender, EventArgs e)
        {
            startTesty.RunWorkerAsync();
        }

        private void startTesty_DoWork(object sender, DoWorkEventArgs e)
        {
                  for (int i = 10; i <= servicesNames.Length - 1; i++)
            {
                ServiceController service = new ServiceController(servicesNames[i]);
                try
                {
                    service.Start();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void stopTesty_DoWork(object sender, DoWorkEventArgs e)
        {
          
            for (int i = 10; i <= servicesNames.Length - 1; i++)
            {
                ServiceController service = new ServiceController(servicesNames[i]);
                try
                {
                    service.Stop();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void stopTestServer_Click(object sender, EventArgs e)
        {
            stopTestServer.Enabled = false;
            stopTesty.RunWorkerAsync();
        }

        private void stopTesty_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startTestServer.Enabled = true;
        }

        private void startTesty_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopTestServer.Enabled = true;
        }

        private void startXelionServer_Click(object sender, EventArgs e)
        {
            startXelion.RunWorkerAsync();
        }

        private void stopXelionServer_Click(object sender, EventArgs e)
        {
            stopXelion.RunWorkerAsync();
        }

        private void startXelion_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 9; i++)
            {
                ServiceController service = new ServiceController(servicesNames[i]);
                try
                {
                    service.Start();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void stopXelion_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 9; i++)
            {
                ServiceController service = new ServiceController(servicesNames[i]);
                try
                {
                    service.Stop();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void startXelion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopXelionServer.Enabled = true;
        }

        private void stopXelion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startXelionServer.Enabled = true;
        }

        private void EnviarReporte()
        {
            //Enviarle Mail a Nostek diciendo que el servidor se cayo D:
            MailMessage mail = new MailMessage("no-reply@coeven.com", sendReportTo);
            SmtpClient client = new SmtpClient();

            client.Host = "smtp.mandrillapp.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("coevengames@gmail.com", "3FSa3y_HdOBJDS5CBEHDhQ");

            mail.IsBodyHtml = true;
            mail.Subject = "[CVN Manager] Servicio Caido";
            mail.Body = "Se notifica que uno o mas servicios se han caido<br/>cvnServiceManager 2015";
            client.Send(mail);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sendReportTo = mailBox.Text;
        }


        public string sendReportTo { get; set; }

        private void startServicesTesty_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + @"\CoevenAct\t01.bat");
            }
            catch(SystemException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void deleteServicesTesty_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + @"\CoevenAct\t02.bat");
            }
            catch (SystemException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void startServiceXelion_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + @"\CoevenAct\x01.bat");
            }
            catch (SystemException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void deleteServiceXelion_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + @"\CoevenAct\x02.bat");
            }
            catch (SystemException ex)
            {
                MessageBox.Show("" + ex);
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {        
            if (isConfigOn == 1)
            { 
                isConfigOn = 0;
                this.Width = 705;
            }
            else
            {
                isConfigOn = 1;
                this.Width = 1055;
            }
        }

        public int isConfigOn { get; set; }
        public int isMantenimiento { get; set; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isMantenimiento = 1;
            }
            else
            {
                isMantenimiento = 0;
            }
        }
    }
}
