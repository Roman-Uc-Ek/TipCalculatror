using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TipCalculator.Maui.Models;

namespace TipCalculator.Maui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ConsumoCompartido _consumo;
        private string _importeDelConsumo = string.Empty;
        private string _numeroDePersonas = "1";
        private string _porcentajeDePropina = "10";

        private string _importeConsumoPorPersona = string.Empty;

        private string _importePropina = string.Empty;

        private string _importePropinaPorPeronsa = string.Empty;

        private string _importeConsumoConPropina =string.Empty;

        private string _importeConsumoConPropinaPorPersona = string.Empty;
         public string ImporteDelConsumo
         {
            get => _importeDelConsumo;
            set 
            {
                if (_importeDelConsumo != value) 
                { 
                    _importeDelConsumo = value;
                    OnPropertyChange(nameof(ImporteDelConsumo));
                }
            }
         }

        public string NumeroDePersonas
        {
            get => _numeroDePersonas;
            set
            {
                if (_numeroDePersonas != value)
                {
                    _numeroDePersonas = value;
                    OnPropertyChange(nameof(NumeroDePersonas));
                }
            }
        }

        public string PorcentajeDePropina
        {
            get => _porcentajeDePropina;
            set
            {
                if (_porcentajeDePropina != value)
                {
                    _porcentajeDePropina = value;
                    OnPropertyChange(nameof(PorcentajeDePropina));
                }
            }
        }

        public string ImporteConsumoPorPersona
        {
            get => _importeConsumoPorPersona;
            set
            {
                if (_importeConsumoPorPersona != value)
                {
                    _importeConsumoPorPersona = value;
                    OnPropertyChange(nameof(ImporteConsumoPorPersona));
                }
            }
        }

        public string ImportePropina
        {
            get => _importePropina;
            set
            {
                if (_importePropina != value)
                {
                    _importePropina = value;
                    OnPropertyChange(nameof(ImportePropina));
                }
                    
            }
        }
        public string ImportePropinaPorPersona
        {
            get => _importePropinaPorPeronsa;
            set
            {
                if (_importePropinaPorPeronsa != value)
                {
                    _importePropinaPorPeronsa = value;
                    OnPropertyChange(nameof(ImportePropinaPorPersona));
                }
            }
        }
        public string ImporteConsumoConPropina
        {
            get => _importeConsumoConPropina;
            set
            {
                if (_importeConsumoConPropina != value)
                {
                    _importeConsumoConPropina = value;
                    OnPropertyChange(nameof(ImporteConsumoConPropina));
                }   
            }
        }
        public string ImporteConsumoConPropinaPorPersona
        {
            get => _importeConsumoConPropinaPorPersona;
            set
            {
                if (_importeConsumoConPropinaPorPersona != value)
                {
                    _importeConsumoConPropinaPorPersona = value;
                    OnPropertyChange(nameof(ImporteConsumoConPropinaPorPersona));
                }
                    
            }
        }

        public ICommand CalcularCommand { get;private set; }
        public ICommand LimpiarCommand { get; private set; }
        public ICommand PorcentajeDePropinaCommand { get; private set; }

        public MainViewModel()
        {
            _consumo = new ConsumoCompartido(0.0m, 10.0m);
            CalcularCommand = new Command(CalcularPropina);
            LimpiarCommand = new Command(LimpiarDatos);
            PorcentajeDePropinaCommand = new Command<string>(ActualizarPorcentajeDePropina);
            
        }

        private void CalcularPropina()
        {
            bool consumoEsValido = false;
            bool numeroDePersonasEsValido = false;
            bool porcentajeDePropinaEsValido = false;
            decimal importeDelConsumo; 
            int numeroDePersonas;
            decimal porcentajeDePropina;
            consumoEsValido = decimal.TryParse(ImporteDelConsumo, out importeDelConsumo);
            numeroDePersonasEsValido = int.TryParse(NumeroDePersonas, out numeroDePersonas);
            porcentajeDePropinaEsValido = decimal.TryParse(PorcentajeDePropina, out porcentajeDePropina);
            if(consumoEsValido 
                && numeroDePersonasEsValido 
                && porcentajeDePropinaEsValido) 
            {
                _consumo = new ConsumoCompartido(importeDelConsumo, porcentajeDePropina, numeroDePersonas);
                //ImporteDelConsumo = _consumo.ImporteDelConsumo.ToString ("F2");
                ImporteConsumoPorPersona = _consumo.ImporteDelCosumoPorPersona.ToString("F2");
                ImportePropina = _consumo.ImportePropina.ToString("F2");
                ImportePropinaPorPersona = _consumo.ImporteDelCosumoPorPersona.ToString("F2");
                ImporteConsumoConPropina = _consumo.ImporteDelConsumoConPropina.ToString("F2");
                ImporteConsumoConPropinaPorPersona = _consumo.ImporteDelConsumoConPropinaPorPersona.ToString("F2");
            }
        }

        private void LimpiarDatos()
        { 
            ImporteDelConsumo = string.Empty;
            NumeroDePersonas = "1";
            PorcentajeDePropina = "10";

            ImporteConsumoPorPersona = string.Empty;
            ImportePropina = string.Empty;
            ImportePropinaPorPersona = string.Empty;
            ImporteConsumoConPropina = string.Empty;
            ImporteConsumoConPropinaPorPersona = string.Empty;
        }
        private void ActualizarPorcentajeDePropina (string nuevoPorcentaje)
        {
            PorcentajeDePropina = nuevoPorcentaje;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName) 
        {
            if (PropertyChanged != null) 
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
            
    }
}
