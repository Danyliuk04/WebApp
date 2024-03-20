using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly Store _context;

        public CardController(Store context)
        {
            _context = context;
        }

        // GET: api/Card
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }

        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // PUT: api/Card/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.CardId)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Card
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            _context.Cards.Add(card);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CardExists(card.CardId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCard", new { id = card.CardId }, card);
        }

        // DELETE: api/Card/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }
[HttpPost("AddWithAdoNet")] 
        public void InsetrCard(Card card)  
        {  
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString =
                "Data Source=localhost;Server=DESKTOP-JKDGH8A\\SQLEXPRESS;Database=ElctronicsStore;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            SqlCommand sqlCmd = new SqlCommand();  
            sqlCmd.CommandType = CommandType.Text;  
            sqlCmd.CommandText = "INSERT INTO Card (creationDate, clientID, discountRate, totalAmountPurchase) Values (@creationDate, @clientID, @discountRate, @totalAmountPurchase)";  
            sqlCmd.Connection = myConnection;  
            
           // sqlCmd.Parameters.AddWithValue("@cardID", card.cardID);  
            sqlCmd.Parameters.AddWithValue("@creationDate", card.CreationDate);
            sqlCmd.Parameters.AddWithValue("@clientID", card.ClientId); 
            sqlCmd.Parameters.AddWithValue("@discountRate", card.DiscountRate); 
            sqlCmd.Parameters.AddWithValue("@totalAmountPurchase", card.TotalAmountPurchase); 
            myConnection.Open();  
            sqlCmd.ExecuteNonQuery();  
            myConnection.Close();  
        }  
        
        [HttpDelete("DeleteWithAdoNet/{id}")]
        public void DeleteCard(int id, Card card)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString =
                "Data Source=localhost;Server=DESKTOP-JKDGH8A\\SQLEXPRESS;Database=ElctronicsStore;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";          SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = $"DELETE FROM Card WHERE cardID = @CardID";
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.Add("@cardID", SqlDbType.Int).Value = id;

            myConnection.Open();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [HttpPut("UpdateWithAdoNet/{id}")]
        public void UpdateCard(int id, Card card)
        {
            if (id == card.CardId)
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString =
                    "Data Source=localhost;Server=DESKTOP-JKDGH8A\\SQLEXPRESS;Database=ElctronicsStore;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"; 
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "UPDATE Card SET clientID = @ClientId WHERE cardID = @cardID";
                sqlCmd.Connection = myConnection;

                sqlCmd.Parameters.Add("@cardID", SqlDbType.Int).Value = id;
                sqlCmd.Parameters.AddWithValue("@clientID", card.ClientId);
                myConnection.Open();
                sqlCmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.CardId == id);
        }
    }
}
