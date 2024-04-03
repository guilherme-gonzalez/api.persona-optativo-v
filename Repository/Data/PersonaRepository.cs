using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace Repository.Data
{
    public class PersonaRepository : IPersona
    {
        private readonly IDbConnection _conexionDB;

        public PersonaRepository(string connectionString)
        {
            _conexionDB = new DbConection(connectionString).dbConnection();
        }

        public bool add(PersonaModel persona)
        {
            try
            {
                var query = "INSERT INTO Persona (nombre, apellido, cedula) VALUES (@Nombre, @Apellido, @Cedula)";
                var affectedRows = _conexionDB.Execute(query, persona);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding persona.", ex);
            }
        }

        public PersonaModel get(int id)
        {
            try
            {
                var query = "SELECT * FROM Persona WHERE id = @Id";
                return _conexionDB.QueryFirstOrDefault<PersonaModel>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving persona.", ex);
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            try
            {
                var query = "SELECT * FROM Persona";
                return _conexionDB.Query<PersonaModel>(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while listing personas.", ex);
            }
        }

        public bool remove(PersonaModel persona)
        {
            try
            {
                var query = "DELETE FROM Persona WHERE id = @Id";
                var affectedRows = _conexionDB.Execute(query, new { Id = persona.Id });
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while removing persona.", ex);
            }
        }

        public bool update(PersonaModel persona)
        {
            try
            {
                var query = "UPDATE Persona SET nombre = @Nombre, apellido = @Apellido, cedula = @Cedula WHERE id = @Id";
                var affectedRows = _conexionDB.Execute(query, persona);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating persona.", ex);
            }
        }
    }
}
