﻿namespace ConsultorioApp.Manager.Interfaces.Repositories
{
    public interface IEspecialidadeRepository
    {
        Task<bool> ExisteAsync(int id);
    }
}
