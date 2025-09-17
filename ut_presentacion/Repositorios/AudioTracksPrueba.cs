using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class AudioTracksPrueba
    {
        private readonly IConexion? iConexion;
        private List<AudioTracks>? lista;
        private AudioTracks? entidad;

        public AudioTracksPrueba()
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
            int id = 23;
            var exist = this.iConexion!.AudioTracks!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.AudioTracks()!;
            exist.Content = newData.Content;
            exist.Language = newData.Language;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.AudioTracks!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}