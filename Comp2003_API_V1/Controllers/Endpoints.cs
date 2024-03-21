using Microsoft.AspNetCore.Mvc;
using Comp2003_API_V1.Context;
using Comp2003_API_V1.Models;
using Comp2003_API_V1.Models.CRUD.Read;
using System.Collections.Generic;

namespace Comp2003_API_V1.Controllers
{
    [ApiController]
    [Route("V2/[controller]")]
    public class Endpoints : ControllerBase
    {
        private readonly ContextFile _context;

        public Endpoints(ContextFile context)
        {
            _context = context;
        }

        [HttpGet("ReadVideo")]
        public async Task<IActionResult> GetVideo(int cocktailID)
        {
            try
            {
                var result = await _context.GetVideoContext(cocktailID);

                if (result != null && result.Any())
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound("No video exists for this id");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ReadCocktailsByIngredient")]
        public async Task<IActionResult> GetCocktailsForIngredient(string ingredientName)
        {
            try
            {
                var result = await _context.GetCocktailsByIngredientContext(ingredientName);
                var cocktailDetailsList = new List<ReadCocktailDetails>();

                foreach (var cocktailDetail in result)
                {
                    var details = await _context.GetCocktailDetailsContext(cocktailDetail.CocktailID);
                    cocktailDetailsList.AddRange(details);
                }


                if (cocktailDetailsList != null && cocktailDetailsList.Any())
                {

                    return Ok(cocktailDetailsList);
                }
                else
                {
                    return NotFound("No cocktail exists for this ingredient");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ReadCocktailByName")]
        public async Task<IActionResult> GetCocktailByName(string cocktailName)
        {
            try
            {
                var result = await _context.GetCocktailByNameContext(cocktailName);
                var cocktailDetailsList = new List<ReadCocktailDetails>();

                foreach (var cocktailDetail in result)
                {
                    var details = await _context.GetCocktailDetailsContext(cocktailDetail.CocktailID);
                    cocktailDetailsList.AddRange(details);
                }

                if (cocktailDetailsList != null && cocktailDetailsList.Any())
                {

                    return Ok(cocktailDetailsList);
                }
                else
                {
                    return NotFound("No cocktail exists for this name");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ReadArticles")]
        public async Task<IActionResult> GetArticle(int cocktailID)
        {
            try
            {
                var result = await _context.GetArticleContext(cocktailID);

                if (result != null && result.Any())
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound("No article exists for this id");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ReadCocktailDetails")]
        public async Task<IActionResult> GetCocktailDetails(int cocktailID) // changed back to swagger to bug fix
        {
            try
            {
                var cocktailDetails = await _context.GetCocktailDetailsContext(cocktailID);

                if (cocktailDetails != null && cocktailDetails.Any())
                {

                    return Ok(cocktailDetails);
                }
                else
                {
                    return NotFound("No cocktail exists for this id");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ReadCocktailTags")]
        public async Task<IActionResult> GetCocktailTags(int cocktailID)
        {
            try
            {
                var result = await _context.ReadCocktailTagsContext(cocktailID);

                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No Tags Exist For This Cocktail.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ReadIngredientsForCocktail")]
        public async Task<IActionResult> GetIngredientsForCocktail(int cocktailID)
        {
            try
            {
                var result = await _context.ReadIngredientsForCocktailContext(cocktailID);

                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No Ingredients Exist For This Cocktail.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ReadCocktailsForTag")]
        public async Task<IActionResult> GetCocktailsForTag(string tagName)
        {
            try
            {
                var result = await _context.ReadCocktailsForTagContext(tagName);
                var cocktailDetailsList = new List<ReadCocktailDetails>();

                foreach (var cocktailDetail in result)
                {
                    var details = await _context.GetCocktailDetailsContext(cocktailDetail.CocktailID);
                    cocktailDetailsList.AddRange(details);
                }

                if (cocktailDetailsList != null && cocktailDetailsList.Any())
                {
                    return Ok(cocktailDetailsList);
                }
                else
                {
                    return NotFound("No Cocktails Exist For This Tag.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ReadUserFavourites")]
        public async Task<IActionResult> GetUserFavourites(string currentEmail)
        {
            try
            {
                var result = await _context.ReadUserFavouritesContext(currentEmail);

                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No Favourites Exist For This User.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ReadUserFlags")]
        public async Task<IActionResult> GetUserFlags(string currentEmail)
        {
            try
            {
                var result = await _context.ReadUserFlagsContext(currentEmail);

                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No Flags Exist For This User.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateUserFlags")]
        public async Task<IActionResult> PutUserFlags([FromBody] PostmanItems items)
        {
            try
            {
                await _context.UpdateUserFlagsContext(items.currentEmail, items.newEmail, Convert.ToInt16(items.ageVerificationFlag), Convert.ToInt16(items.notificationFlag));
                return Ok("Updated User Flags");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("cocktails/DeleteFavouriteCocktail/")]
        public async Task<IActionResult> DeleteFavouriteCocktail([FromBody] PostmanItems items)
        {
            try
            {
                await _context.DeleteFavouriteCocktailContext(items.cocktailID, items.currentEmail);

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateNewFavourite")]
        public async Task<IActionResult> PostNewFavourite([FromBody] PostmanItems items)
        {
            try
            {
                await _context.CreateNewFavouriteContext(items.currentEmail, items.cocktailID);
                return Ok("Favourited Cocktail");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("CreateUserFlag")]
        public async Task<IActionResult> CreateUserFlag([FromBody] PostmanItems items)
        {
            try
            {
                await _context.CreateUserFlagsContext(items.currentEmail, Convert.ToInt16(items.ageVerificationFlag), Convert.ToInt16(items.notificationFlag));

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
