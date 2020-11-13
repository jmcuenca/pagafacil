using System.Web.Http;
using WebActivatorEx;
using WebApiCore;
using Swashbuckle.Application;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiCore
{
    public class SwaggerConfig
    {
        protected static string GetXmlCommentsPath()
        {
            return Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "bin", "WebApiCore.xml");
        }

        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "PagoFacil API")
                           .Description("Api para el sistema de pagos PagoFácil")
                           .TermsOfService("Términos de servicio.")
                           .Contact(x => x
                               .Name("Juan Cuenca, Bryan Vera")
                               .Url("http://www.pagafacil.com/")
                               .Email("info@pagafacil.com"))
                           .License(x => x
                               .Name("Licencia")
                               .Url("http://www.pagafacil.com/license"));

                        c.IncludeXmlComments(GetXmlCommentsPath());

                        // NOTE: You must also configure 'EnableApiKeySupport' below in the SwaggerUI section
                        //
                        // HABILITAMOS LA AUTENTICACIÓN JWT.
                        c.ApiKey("Authorization")
                        .Description("Introduce el Token JWT aquí.")
                        .Name("Bearer")
                        .In("header");

                        // If you want the output Swagger docs to be indented properly, enable the "PrettyPrint" option.
                        //
                        c.PrettyPrint();

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.EnableApiKeySupport("Authorization", "header");

                    });
        }
    }
}
