﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EL;

namespace DAL
{
    public static class DAL_Roles
    {
        //Insert
        public static Roles InsertRoles(Roles Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Roles.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static Roles InsertarRoles(Roles Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
               Roles Registro_a_Guardar = new Roles();

                Registro_a_Guardar.Rol = Entidad.Rol;
                Registro_a_Guardar.IdUsuarioRegistra = Entidad.IdUsuarioRegistra;
                Registro_a_Guardar.Activo = true;
                Registro_a_Guardar.FechaRegistro = DateTime.Now;

                bd.Roles.Add(Registro_a_Guardar);
                bd.SaveChanges();
                return Registro_a_Guardar;

            }
        }

        //Update
        public static bool Update(Roles Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var RegistroBD = bd.Roles.Find(Entidad.IdRol);
                RegistroBD.Rol= Entidad.Rol;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Actualizar(Roles Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var RegistroBD = (from tabla in bd.Roles where tabla.IdRol == Entidad.IdRol select tabla).SingleOrDefault();

                if (RegistroBD != null)
                {
                    RegistroBD.Rol = Entidad.Rol;
                    RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                    RegistroBD.FechaActualizacion = DateTime.Now;
                    return bd.SaveChanges() > 0;
                }
                return false;
            }
        }

        //Delete
        public static bool Delete(Roles Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var RegistroBD = bd.Roles.Find(Entidad.IdRol);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Eliminar(Roles Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var RegistroBD = (from tabla in bd.Roles where tabla.IdRol == Entidad.IdRol select tabla).SingleOrDefault();

                if (RegistroBD != null)
                {
                    RegistroBD.Activo =false;
                    RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                    RegistroBD.FechaActualizacion = DateTime.Now;
                    return bd.SaveChanges() > 0;
                }
                return false;
            }
        }

        //Select Todos los Registros
        public static List<Roles> List(bool Activo = true)
        {
            using (BDDinamicWeb bd= new BDDinamicWeb())
            {
                return bd.Roles.Where(a => a.Activo == Activo).ToList();
            }
        }
        public static List<Roles> Lista(bool Activo = true)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return (from tabla in bd.Roles where tabla.Activo == Activo select tabla).ToList();
            }
        }

        //Select Un Registro
        public static Roles Registro_(int IdRegistro)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return bd.Roles.Where(a => a.IdRol == IdRegistro).SingleOrDefault();
            }
        }
        public static Roles Registro__(int IdRegistro)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return bd.Roles.Find(IdRegistro);
            }
        }
        public static Roles Registro___(int IdRegistro)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return (from tabla in bd.Roles where tabla.IdRol == IdRegistro select tabla).SingleOrDefault();
            }
        }


        //Select Dinamico
        public static List<Roles> Buscar(string Palabra)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return bd.Roles.Where(a=>a.Rol.Contains(Palabra)).ToList();
            }
        }

        public static List<Roles> Buscar_(string Palabra)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return (from tabla in bd.Roles 
                        where tabla.Rol.Contains(Palabra) 
                        select tabla).ToList();    
            }
        }




    }
}
