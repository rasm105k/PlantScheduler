import sql from 'mssql';

// Your SQL Server connection settings
const config = {
  server: 'localhost\\SQLEXPRESS',       
  database: 'PlantDb',
  options: {
    encrypt: true,
    trustConnection: true,      
    trustServerCertificate: true
  }
};

export default class PlantRepository 
{
    getPlants() {

        const pool = sql.connect(config);
        const result = pool.request().query('SELECT TOP 10 * FROM Plants');      
        sql.close();

        return result.recordset;

    }
}
