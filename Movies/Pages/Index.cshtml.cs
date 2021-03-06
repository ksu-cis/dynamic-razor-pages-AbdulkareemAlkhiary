﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {



        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty]
        public string[] Genres { get; set; }


        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }


        /// <summary>
        /// Gets and sets the search terms
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; }

        /// <summary>
        /// Gets and sets the MPAA rating filters
        /// </summary>
        [BindProperty]
        public string[] MPAARating { get; set; }


        /// <summary>
        /// Gets and sets the IMDB minimium rating
        /// </summary>
        [BindProperty]
        public double? IMDBMin { get; set; }

        /// <summary>
        /// Gets and sets the IMDB maximum rating
        /// </summary>
        [BindProperty]
        public double? IMDBMax { get; set; }

        /// <summary>
        /// Does the response initialization for incoming GET requests
        /// </summary>
        public void OnGet(double? IMDBMin, double? IMDBMax)
        {
            /*
            // Nullable conversion workaround
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            MPAARating = Request.Query["MPAARatings"];
            Genres = Request.Query["Genres"];
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARating);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            */

            Movies = MovieDatabase.All;
            // Search movie titles for the SearchTerms
            if (SearchTerms != null)
            {
                Movies = Movies.Where(movie => movie.Title != null && movie.Title.Contains(SearchTerms, StringComparison.InvariantCultureIgnoreCase));
            }
            // Filter by MPAA Rating 
            if (MPAARating != null && MPAARating.Length != 0)
            {
                Movies = Movies.Where(movie =>
                    movie.MPAARating != null &&
                    MPAARating.Contains(movie.MPAARating)
                    );
            }



        }



    }
}
