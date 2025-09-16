using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IAudioTracksAplicacion
    {
        void Configurar(string StringConexion);

        List<AudioTracks> Listar();
        AudioTracks? Guardar(AudioTracks? entidad);
        AudioTracks? Modificar(AudioTracks? entidad);
        AudioTracks? Borrar(AudioTracks? entidad);
    }
}