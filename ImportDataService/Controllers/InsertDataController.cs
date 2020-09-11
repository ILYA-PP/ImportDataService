using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ImportDataService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Npgsql;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ImportDataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsertDataController : ControllerBase
    {
        private FileSettings fileSettings;
        private NpgsqlConnection connection;
        private AppDbContext db;
        public InsertDataController(IOptions<FileSettings> _fileSettings, IConfiguration config, AppDbContext dbContext)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            fileSettings = _fileSettings.Value;
            connection = new NpgsqlConnection(config.GetConnectionString("DefaultConnection"));
            db = dbContext;
        }
        [HttpGet("/api/[controller]/scan")]
        public IActionResult ScanFolder()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(fileSettings.FirstFolder);
                if (dir.GetFiles().Length > 0)
                {
                    foreach (var file in dir.GetFiles())
                    {
                        if (file.Name == fileSettings.StockFile)
                            InsertInStock();
                        else if (file.Name == fileSettings.GoodsFile)
                            InsertInGoods();
                        else if (file.Name == fileSettings.PriceFile)
                            InsertInPrice();
                        else if (file.Name == fileSettings.CityFile)
                            InsertInCity();
                        else if (file.Name == fileSettings.PharmacyFile)
                            InsertInPharmacy();
                        else if (file.Name == fileSettings.RegionFile)
                            InsertInRegions();
                    }
                }
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/api/[controller]/stock")]
        public IActionResult InsertInStock()
        {
            try
            {
                string path = $"{fileSettings.FirstFolder}\\{fileSettings.StockFile}";
                NpgsqlCommand command = new NpgsqlCommand($@"COPY temp_stock FROM '{path}';", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                System.IO.File.Move(path, $"{fileSettings.SecondFolder}\\{fileSettings.StockFile}");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("/api/[controller]/sku")]
        public IActionResult InsertInGoods()
        {
            try
            {
                string path = $"{fileSettings.FirstFolder}\\{fileSettings.GoodsFile}";
                NpgsqlCommand command = new NpgsqlCommand($@"COPY temp_sku FROM '{path}';", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                System.IO.File.Move(path, $"{fileSettings.SecondFolder}\\{fileSettings.GoodsFile}");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("/api/[controller]/price")]
        public IActionResult InsertInPrice()
        {
            try
            {
                string path = $"{fileSettings.FirstFolder}\\{fileSettings.PriceFile}";
                NpgsqlCommand command = new NpgsqlCommand($@"COPY temp_price FROM '{path}';", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                System.IO.File.Move(path, $"{fileSettings.SecondFolder}\\{fileSettings.PriceFile}");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("/api/[controller]/city")]
        public IActionResult InsertInCity()
        {
            try
            {
                string path = $"{fileSettings.FirstFolder}\\{fileSettings.CityFile}";
                string json = System.IO.File.ReadAllText(path, Encoding.GetEncoding(1251));
                var cities = JsonSerializer.Deserialize<temp_city[]>(json);
                if (db.Cities.Count() > 0)
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE temp_city");
                db.Cities.AddRange(cities);
                db.SaveChanges();
                System.IO.File.Move(path, $"{fileSettings.SecondFolder}\\{fileSettings.CityFile}");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("/api/[controller]/location")]
        public IActionResult InsertInPharmacy()
        {
            try
            {
                string path = $"{fileSettings.FirstFolder}\\{fileSettings.PharmacyFile}";
                package_datecreate phar;
                var ser = new XmlSerializer(typeof(package_datecreate));
                using (var xml = System.IO.File.OpenRead(path))
                    phar = (package_datecreate)ser.Deserialize(xml);
                if (db.Pharmacies.Count() > 0)
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE temp_location");
                db.Pharmacies.AddRange(phar.locations);
                db.SaveChanges();
                System.IO.File.Move(path, $"{fileSettings.SecondFolder}\\{fileSettings.PharmacyFile}");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("/api/[controller]/region")]
        public IActionResult InsertInRegions()
        {
            try
            {
                string path = $"{fileSettings.FirstFolder}\\{fileSettings.RegionFile}";
                string json = System.IO.File.ReadAllText(path, Encoding.GetEncoding(1251));
                var regions = JsonSerializer.Deserialize<temp_region[]>(json);
                if(db.Regions.Count() > 0)
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE temp_region");
                db.Regions.AddRange(regions);
                db.SaveChanges();
                System.IO.File.Move(path, $"{fileSettings.SecondFolder}\\{fileSettings.RegionFile}");
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}