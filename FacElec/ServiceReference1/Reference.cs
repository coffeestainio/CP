//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//     //
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="https://www.facturaelectronica.cr", ConfigurationName="GTICargaFacturaSoap")]
public interface GTICargaFacturaSoap
{
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/InsertarDocumentos", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<string> InsertarDocumentosAsync(string pvcDocumentosXML, string pvcCorreoUsuario, string pvcClaveUsuario);
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/InsertarFacturaPagada", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<string> InsertarFacturaPagadaAsync(string pvcDocumentosXML, string pvcCorreoUsuario, string pvcClaveUsuario);
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/PagarFactura", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<decimal> PagarFacturaAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcNotaTransaccion, string pvcCorreoUsuario, string pvcClaveUsuario);
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/ConsultaDocumento", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<string> ConsultaDocumentoAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcCorreoUsuario, string pvcClaveUsuario);
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/ConsultaRespuestaHacienda", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<string> ConsultaRespuestaHaciendaAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcCorreoUsuario, string pvcClaveUsuario);
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/ConsultaRespuestaCorreo", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<string> ConsultaRespuestaCorreoAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcCorreoUsuario, string pvcClaveUsuario);
    
    [System.ServiceModel.OperationContractAttribute(Action="https://www.facturaelectronica.cr/ProcesarDocCredenciales", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    System.Threading.Tasks.Task<string> ProcesarDocCredencialesAsync(string pvcClaveWS);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
public interface GTICargaFacturaSoapChannel : GTICargaFacturaSoap, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
public partial class GTICargaFacturaSoapClient : System.ServiceModel.ClientBase<GTICargaFacturaSoap>, GTICargaFacturaSoap
{
    
    /// <summary>
    /// Implemente este método parcial para configurar el punto de conexión de servicio.
    /// </summary>
    /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
    /// <param name="clientCredentials">Credenciales de cliente</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
    
    public GTICargaFacturaSoapClient(EndpointConfiguration endpointConfiguration) : 
            base(GTICargaFacturaSoapClient.GetBindingForEndpoint(endpointConfiguration), GTICargaFacturaSoapClient.GetEndpointAddress(endpointConfiguration))
    {
        this.Endpoint.Name = endpointConfiguration.ToString();
        ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
    }
    
    public GTICargaFacturaSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
            base(GTICargaFacturaSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
    {
        this.Endpoint.Name = endpointConfiguration.ToString();
        ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
    }
    
    public GTICargaFacturaSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(GTICargaFacturaSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
    {
        this.Endpoint.Name = endpointConfiguration.ToString();
        ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
    }
    
    public GTICargaFacturaSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public System.Threading.Tasks.Task<string> InsertarDocumentosAsync(string pvcDocumentosXML, string pvcCorreoUsuario, string pvcClaveUsuario)
    {
        return base.Channel.InsertarDocumentosAsync(pvcDocumentosXML, pvcCorreoUsuario, pvcClaveUsuario);
    }
    
    public System.Threading.Tasks.Task<string> InsertarFacturaPagadaAsync(string pvcDocumentosXML, string pvcCorreoUsuario, string pvcClaveUsuario)
    {
        return base.Channel.InsertarFacturaPagadaAsync(pvcDocumentosXML, pvcCorreoUsuario, pvcClaveUsuario);
    }
    
    public System.Threading.Tasks.Task<decimal> PagarFacturaAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcNotaTransaccion, string pvcCorreoUsuario, string pvcClaveUsuario)
    {
        return base.Channel.PagarFacturaAsync(pvnIdEmpresa, pvcConsecutivo, pvcNotaTransaccion, pvcCorreoUsuario, pvcClaveUsuario);
    }
    
    public System.Threading.Tasks.Task<string> ConsultaDocumentoAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcCorreoUsuario, string pvcClaveUsuario)
    {
        return base.Channel.ConsultaDocumentoAsync(pvnIdEmpresa, pvcConsecutivo, pvcCorreoUsuario, pvcClaveUsuario);
    }
    
    public System.Threading.Tasks.Task<string> ConsultaRespuestaHaciendaAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcCorreoUsuario, string pvcClaveUsuario)
    {
        return base.Channel.ConsultaRespuestaHaciendaAsync(pvnIdEmpresa, pvcConsecutivo, pvcCorreoUsuario, pvcClaveUsuario);
    }
    
    public System.Threading.Tasks.Task<string> ConsultaRespuestaCorreoAsync(int pvnIdEmpresa, string pvcConsecutivo, string pvcCorreoUsuario, string pvcClaveUsuario)
    {
        return base.Channel.ConsultaRespuestaCorreoAsync(pvnIdEmpresa, pvcConsecutivo, pvcCorreoUsuario, pvcClaveUsuario);
    }
    
    public System.Threading.Tasks.Task<string> ProcesarDocCredencialesAsync(string pvcClaveWS)
    {
        return base.Channel.ProcesarDocCredencialesAsync(pvcClaveWS);
    }
    
    public virtual System.Threading.Tasks.Task OpenAsync()
    {
        return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
    }
    
    public virtual System.Threading.Tasks.Task CloseAsync()
    {
        return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
    }
    
    private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
    {
        if ((endpointConfiguration == EndpointConfiguration.GTICargaFacturaSoap))
        {
            System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
            result.MaxBufferSize = int.MaxValue;
            result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            result.MaxReceivedMessageSize = int.MaxValue;
            result.AllowCookies = true;
            return result;
        }
        if ((endpointConfiguration == EndpointConfiguration.GTICargaFacturaSoap12))
        {
            System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
            System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
            textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
            result.Elements.Add(textBindingElement);
            System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
            httpBindingElement.AllowCookies = true;
            httpBindingElement.MaxBufferSize = int.MaxValue;
            httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
            result.Elements.Add(httpBindingElement);
            return result;
        }
        throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
    }
    
    private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
    {
        if ((endpointConfiguration == EndpointConfiguration.GTICargaFacturaSoap))
        {
            return new System.ServiceModel.EndpointAddress("http://pruebas.gticr.com/WSCargaFacturaAsync/Pruebas/GTICargaFactura.asmx");
        }
        if ((endpointConfiguration == EndpointConfiguration.GTICargaFacturaSoap12))
        {
            return new System.ServiceModel.EndpointAddress("http://pruebas.gticr.com/WSCargaFacturaAsync/Pruebas/GTICargaFactura.asmx");
        }
        throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
    }
    
    public enum EndpointConfiguration
    {
        
        GTICargaFacturaSoap,
        
        GTICargaFacturaSoap12,
    }
}
