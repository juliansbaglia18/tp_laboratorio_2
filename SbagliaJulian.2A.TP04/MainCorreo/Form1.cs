﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Correo correo;
        public Form1()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += this.paq_InformaEstado;
                this.correo += nuevoPaquete;
            }
            catch (TrackingRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                if (((Paquete)sender).Estado == Paquete.EEstado.Entregado)
                {
                    try
                    {
                        PaqueteDAO.Insertar((Paquete)sender);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error durante la carga de datos." +
                            " El error presenta el siguiente mensaje:\n" + ex.Message);
                    }
                }
                this.ActualizarEstados();
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Clear();
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                if (elemento is Correo)
                {
                    elemento.MostrarDatos(elemento).Guardar("paquetes_Correo");
                }
            }
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                if (item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);
                }

                else if (item.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else if (item.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(item);
                }
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.correo.FinEntrega();
        }
    }
}
