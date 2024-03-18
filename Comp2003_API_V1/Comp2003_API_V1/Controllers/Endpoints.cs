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
        public async Task<IActionResult> GetVideo([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.GetVideoContext(items.cocktailID);

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
        public async Task<IActionResult> GetCocktailsForIngredient([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.GetCocktailsByIngredientContext(items.ingredientName);
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
        public async Task<IActionResult> GetCocktailByName([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.GetCocktailByNameContext(items.cocktailName);
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
        public async Task<IActionResult> GetArticle([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.GetArticleContext(items.cocktailID);

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
        public async Task<IActionResult> GetCocktailDetails([FromBody] PostmanItems items)
        {
            try
            {
                var cocktailDetails = await _context.GetCocktailDetailsContext(items.cocktailID);

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
        public async Task<IActionResult> GetCocktailTags([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.ReadCocktailTagsContext(items.cocktailID);

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
        public async Task<IActionResult> GetIngredientsForCocktail([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.ReadIngredientsForCocktailContext(items.cocktailID);

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
        public async Task<IActionResult> GetCocktailsForTag([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.ReadCocktailsForTagContext(items.tagName);
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
        public async Task<IActionResult> GetUserFavourites([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.ReadUserFavouritesContext(items.currentEmail);

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
        public async Task<IActionResult> GetUserFlags([FromBody] PostmanItems items)
        {
            try
            {
                var result = await _context.ReadUserFlagsContext(items.currentEmail);

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
