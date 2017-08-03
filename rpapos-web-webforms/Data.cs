using rpapos_web_webforms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rpapos_web_webforms
{
    public class Data
    {
        static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }

        public List<UnidadMedida> UnidadesDeMedida = new List<UnidadMedida>
        {
            new UnidadMedida
            {
                Unidad_Medida = 1,
                Descripcion = "unidad 1",
                Simbolo = "sim1",
                Estado = 1,
                Fecha_Hora = new DateTime(),
                M_Fecha_Hora = new DateTime(),
                M_UserName = "Usuario 1",
                UserName = "Usuario 1",
                Orden = 1
            },
             new UnidadMedida
            {
                Unidad_Medida = 2,
                Descripcion = "unidad 2",
                Simbolo = "sim2",
                Estado = 2,
                Fecha_Hora = new DateTime(),
                M_Fecha_Hora = new DateTime(),
                M_UserName = "Usuario 2",
                UserName = "Usuario 2",
                Orden = 2
            },
              new UnidadMedida
            {
                Unidad_Medida = 3,
                Descripcion = "unidad 3",
                Simbolo = "sim3",
                Estado = 3,
                Fecha_Hora = new DateTime(),
                M_Fecha_Hora = new DateTime(),
                M_UserName = "Usuario 3",
                UserName = "Usuario 3",
                Orden = 3
            },
               new UnidadMedida
            {
                Unidad_Medida = 4,
                Descripcion = "unidad 4",
                Simbolo = "sim4",
                Estado = 4,
                Fecha_Hora = new DateTime(),
                M_Fecha_Hora = new DateTime(),
                M_UserName = "Usuario 4",
                UserName = "Usuario 4",
                Orden = 4
            }, new UnidadMedida
            {
                Unidad_Medida = 5,
                Descripcion = "unidad 5",
                Simbolo = "sim5",
                Estado = 5,
                Fecha_Hora = new DateTime(),
                M_Fecha_Hora = new DateTime(),
                M_UserName = "Usuario 5",
                UserName = "Usuario 5",
                Orden = 5
            }
        };

    }
}