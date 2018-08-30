﻿using System;
using System.IO;
using System.Reflection;
using FacElec.helpers;
using FacElec.sync;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;

namespace FacElec
{
    class Program
    {   
        static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {

            var ambiente = "Development";

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            SetupLogguer();

            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            SqlHelper.sqlConnection = Configuration.GetConnectionString(ambiente);

            log.Info("Ejecutando el servicio de sincronizacion de facturas");

            Sincronizador.SincronizarFacturas();

            log.Info("Finalizando el servicio de sincronizacion de facturas");

        }



        private static void SetupLogguer(){
            Sincronizador.log = log;
            SqlHelper.log = log;
            XmlHelper.log = log;
            PdfHelper.log = log;
            AdemarHelper.log = log;
            ValidatorHelper.log = log;
        }
    }
}
