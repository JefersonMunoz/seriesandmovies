using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class AudioTracksPruebas
    {
        private readonly IConexion? iConexion;
        private List<AudioTracks>? lista;
        private AudioTracks? entidad;

        public AudioTracksPruebas()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.AudioTracks!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.AudioTracks()!;
            this.iConexion!.AudioTracks!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Id = 5;
            var entry = this.iConexion!.Entry<AudioTracks>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.AudioTracks!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        //public bool Listar()
        //{
        //    this.lista = this.iConexion!.AudioTracks!.ToList();
        //    if (lista.Count > 0)
        //    {
        //        foreach (var track in lista)
        //        {
        //            Console.WriteLine($"ID: {track.Id}");
        //        }
        //        return true;
        //    }
        //    Console.WriteLine("No hay registros en la tabla AudioTracks.");
        //    return false;
        //}


        //public bool Guardar()
        //{
        //    this.entidad = EntidadesNucleo.AudioTracks()!;
        //    this.iConexion!.AudioTracks!.Add(this.entidad);
        //    this.iConexion!.SaveChanges();
        //    Console.WriteLine($"Registro guardado con Id {this.entidad.Id}");
        //    return true;
        //}


        //public bool Modificar()
        //{
        //    int id = 19;
        //    var exist = this.iConexion!.AudioTracks!.FirstOrDefault(t => t.Id == id);
        //    if (exist == null)
        //    {
        //        Console.WriteLine($"El registro {id} no existe en la tabla Audio_track");
        //        return true;
        //    }

        //    var newData = EntidadesNucleo.AudioTracks()!;
        //    exist.Content = newData.Content;
        //    exist.Language = newData.Language;
        //    this.iConexion.Entry(exist).State = EntityState.Modified;
        //    this.iConexion.SaveChanges();

        //    Console.WriteLine($"Registro {id} fue actualizado correctamente.");
        //    return true;
        //}

        //public bool Borrar()
        //{
        //    int id = 22; //Parámetro fijo
        //    var exist = this.iConexion!.AudioTracks!.FirstOrDefault(t => t.Id == id);
        //    if (exist == null)
        //    {
        //        Console.WriteLine($"El registro {id} no existe en la tabla Audio_track");
        //        return true; 
        //    }

        //    this.iConexion.AudioTracks!.Remove(exist);
        //    this.iConexion.SaveChanges();

        //    Console.WriteLine($"Registro {id} eliminado correctamente.");
        //    return true;
        //}


    }
}