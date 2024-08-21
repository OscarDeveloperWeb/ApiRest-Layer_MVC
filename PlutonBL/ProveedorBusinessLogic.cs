using PlutonBE;
using PlutonDA;
using System;
using System.Collections.Generic;
namespace PlutonBL

{
    public class ProveedorBusinessLogic
    {
        public Proveedor SelectById(int idProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                Proveedor beProveedor;

                beProveedor = daProveedor.SelectById(idProveedor);
                return beProveedor;
            }
            catch (Exception ex)
            {
                // Se habilita un log de eventos

                throw ex;
            }
        }

        public void Insert(Proveedor beProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();

                daProveedor.Insert(beProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int idProveedor, Proveedor beProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                daProveedor.Update(idProveedor, beProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                daProveedor.Delete(idProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
