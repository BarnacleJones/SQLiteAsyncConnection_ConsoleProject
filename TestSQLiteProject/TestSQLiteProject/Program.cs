using SQLiteConsoleApp.DiscogsInsight.Database.Entities;
using SQLiteConsoleApp.DiscogsInsight.Database.Services;
using System.Diagnostics.Metrics;

namespace SQLiteConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //To use, download the .db3 file in the repo which is the database called DiscogsInsight.db3. 
                //Defined in constants. Just using desktop as the file path
                //Created to test and debug queries and work out how to use SQLiteAsyncConnection QueryAsync



                var _db = new SQLiteAsyncConnectionAdapter();
                #region Commented out tests/examples
                //Insert a new item
                //var newItem = new Artist
    //            {
    //                Name = "Test Item",
    //                DiscogsArtistId = 99999999,
    //                Profile = "asdf123"
    //            };
    //            await _db.InsertAsync(newItem);

    //            // Retrieve and display all items
    //            var items = await _db.Table<Artist>().ToListAsync();
    //            foreach (var item in items)
    //            {
    //                Console.WriteLine($"Artist ID: {item.Id}, Artist Name: {item.Name}");
    //            }

    //            // Update an item
    //            newItem.Name = "Updated Test Item";
    //            await _db.UpdateAsync(newItem);

    //            // Display updated items
    //            items = await _db.Table<Artist>().Where(x => x.DiscogsArtistId == 99999999).ToListAsync();
    //            foreach (var item in items)
    //            {
    //                Console.WriteLine($"Updated Item ID: {item.Id},  Updated Name: {item.Name}");
    //            }

    //            ////---------------------------------------------------------------------------------------------------------------------------------------------
    //            /////GetReleaseDataModelsByDiscogsGenreTagId(int discogsGenreTagId) 
    //            ///

    //            var discogsGenreTagId = 1;
    //            var releasesWithThisGenreIdQuery = @"
    //                SELECT DiscogsReleaseId
    //                FROM DiscogsGenreTagToDiscogsRelease
    //                WHERE DiscogsGenreTagId = ?;";

    //            var discogsReleaseIds = await _db.QueryAsync<DiscogsReleaseIdClass>(releasesWithThisGenreIdQuery, discogsGenreTagId);

    //            foreach (var id in discogsReleaseIds)
    //            {
    //                Console.WriteLine($"Release with Genre tag 1: DiscogsReleaseId: {id.DiscogsReleaseId}");
    //            }


    //            ////---------------------------------------------------------------------------------------------------------------------------------------------
    //            //GetReleaseInterimDataModelListByDiscogsReleaseIds(List<int> discogsReleaseIds)

    //            var newDiscogsReleaseIds = new List<int>
    //            {
    //                4870222 ,
    //                5186742 ,
    //                6713448 ,
    //                6338923 ,
    //                6271897 ,
    //                11966124,
    //                18471076,
    //                12641837,
    //                12642716
    //            };
    //            var data = string.Join(",", newDiscogsReleaseIds);
    //            var releasesByReleaseIdsQuery = @$"
    //            SELECT 
    //            Release.Year,
    //            Release.OriginalReleaseYear, 
    //            Release.Title,
    //            Artist.Name as Artist,
    //            Release.ReleaseNotes,
    //            Release.ReleaseCountry,
    //            Release.DiscogsArtistId,
    //            Release.DiscogsReleaseId,
    //            Release.MusicBrainzReleaseId,
    //            Release.DiscogsReleaseUrl,
    //            Release.DateAdded,
    //            Release.IsFavourited,
    //            Release.HasAllApiData
    //            FROM Release
    //            INNER JOIN Artist on Release.DiscogsArtistId = Artist.DiscogsArtistId
    //            WHERE Release.DiscogsReleaseId in ({data});";

    //            var releasesByReleaseIds = await _db.QueryAsync<ReleaseInterimData>(releasesByReleaseIdsQuery);

    //            foreach (var release in releasesByReleaseIds)
    //            {
    //                Console.WriteLine(
    //                    $"Year: {release.Year}, " +
    //                    $"Original Release Year: {release.OriginalReleaseYear}, " +
    //                    $"Title: {release.Title}, " +
    //                    $"Artist: {release.Artist}, " +
    //                    $"Release Notes: {release.ReleaseNotes}, " +
    //                    $"Release Country: {release.ReleaseCountry}, " +
    //                    $"Discogs Artist ID: {release.DiscogsArtistId}, " +
    //                    $"Discogs Release ID: {release.DiscogsReleaseId}, " +
    //                    $"MusicBrainz Release ID: {release.MusicBrainzReleaseId}, " +
    //                    $"Discogs Release URL: {release.DiscogsReleaseUrl}, " +
    //                    $"Date Added: {release.DateAdded}, " +
    //                    $"Is Favourited: {release.IsFavourited}, " +
    //                    $"Has All API Data: {release.HasAllApiData}"
    //                );
    //            }



    //            ////---------------------------------------------------------------------------------------------------------------------------------------------
    //            ///SetMusicBrainzArtistDataForSavingAndSaveTagsFromArtistResponse(MusicBrainzInitialArtist artistResponse, Database.Entities.Artist existingArtist)

    //            var tagNamesInResponse = new List<string>()
    //            {
    //                "group sounds",
    //                "likedis auto",
    //                  "country",
    //                  "country pop",
    //                  "nashville sound",
    //                  "2008 universal fire victim",
    //                  "nuno",
    //                  "rock",
    //                  "jazz",
    //                  "hard rock",
    //                  "jazz rock"

    //            };
    //            var quotedTags = string.Join(", ", tagNamesInResponse.Select(tag => $"'{tag}'"));
    //            var musicBrainsTagRecordsForGivenTagsDbQuery = @$"
    //                                                    SELECT Id, Tag
    //                                                    FROM MusicBrainzTags
    //                                                    WHERE Tag IN ({quotedTags});
    //                                                    ";
    //            var reponseTagNamesAlreadyInDbClassObject = await _db.QueryAsync<MusicBrainzTags>(musicBrainsTagRecordsForGivenTagsDbQuery);

    //            foreach (var responseIdAndTag in reponseTagNamesAlreadyInDbClassObject)
    //            {
    //                Console.WriteLine($"{responseIdAndTag.Id} - {responseIdAndTag.Tag}");
    //            }



    //            ////---------------------------------------------------------------------------------------------------------------------------------------------
    //            //private async Task SaveReleasesFromMusicBrainzArtistCall(string musicBrainzArtistId, int? discogsArtistId)
    //            var musicBrainzArtistId = "1d543e07-d0d2-4834-a8db-d65c50c2a856";
    //            var existingMusicBrainzReleaseIdIdsForThisArtistQuery = @$"
    //            SELECT MusicBrainzReleaseId
    //            FROM MusicBrainzArtistToMusicBrainzRelease
    //            WHERE MusicBrainzArtistToMusicBrainzRelease.MusicBrainzArtistId = ?;";

    //            var existingMusicBrainzReleaseIdsForThisArtist = await _db.QueryAsync<MusicBrainzReleaseIdResponse>(existingMusicBrainzReleaseIdIdsForThisArtistQuery, musicBrainzArtistId);

    //            foreach (var item in existingMusicBrainzReleaseIdsForThisArtist)
    //            {
    //                Console.WriteLine($"{item.MusicBrainzReleaseId}");
    //            }


    //            ////---------------------------------------------------------------------------------------------------------------------------------------------
    //            ///Task<List<ReleaseInterimData>> GetReleaseInterimDataModelByDiscogsReleaseId(int discogsReleaseId)
    //            ///
    //            var discogsReleaseId = 4870222;
    //            var releasesByReleaseIdsQueryTwo = @$"
    //            SELECT 
    //            Release.Year,
    //            Release.OriginalReleaseYear, 
    //            Release.Title,
    //            Artist.Name as Artist,
    //            Release.ReleaseNotes,
    //            Release.ReleaseCountry,
    //            Release.DiscogsArtistId,
    //            Release.DiscogsReleaseId,
    //            Release.MusicBrainzReleaseId,
    //            Release.DiscogsReleaseUrl,
    //            Release.DateAdded,
    //            Release.IsFavourited,
    //            Release.HasAllApiData
    //            FROM Release
    //            INNER JOIN Artist on Release.DiscogsArtistId = Artist.DiscogsArtistId
    //            WHERE Release.DiscogsReleaseId = ?;";

    //            var releasesByReleaseIdsTwo = await _db.QueryAsync<ReleaseInterimData>(releasesByReleaseIdsQueryTwo, discogsReleaseId);

    //            foreach (var release in releasesByReleaseIdsTwo)
    //            {
    //                Console.WriteLine(
    //                    $"Year: {release.Year}, " +
    //                    $"Original Release Year: {release.OriginalReleaseYear}, " +
    //                    $"Title: {release.Title}, " +
    //                    $"Artist: {release.Artist}, " +
    //                    $"Release Notes: {release.ReleaseNotes}, " +
    //                    $"Release Country: {release.ReleaseCountry}, " +
    //                    $"Discogs Artist ID: {release.DiscogsArtistId}, " +
    //                    $"Discogs Release ID: {release.DiscogsReleaseId}, " +
    //                    $"MusicBrainz Release ID: {release.MusicBrainzReleaseId}, " +
    //                    $"Discogs Release URL: {release.DiscogsReleaseUrl}, " +
    //                    $"Date Added: {release.DateAdded}, " +
    //                    $"Is Favourited: {release.IsFavourited}, " +
    //                    $"Has All API Data: {release.HasAllApiData}"
    //                );
    //            }

    //            //______________________________________________________________________________________________________________________________________
    //            //Select count of tracks by release id
    //            // Select count of tracks by release id
    //            var discogsReleaseIdForTheCountQuery = 5978377;
    //            var countQuery = @"
    //SELECT COUNT(*)
    //FROM Track
    //WHERE DiscogsReleaseId = ?;";

    //            // Use ExecuteScalarAsync<int> for a count query
    //            var countShouldBeEight = await _db.ExecuteScalarAsync<int>(countQuery, discogsReleaseIdForTheCountQuery);
    //            Console.WriteLine($"Count is: {countShouldBeEight}");



    //            ////_________________________________________________________________________________________________________________________________________
    //            ///select genre tags that are in a list of strings
    //            ///

    //            var asdfs = new List<string> { "Rock", "Pop", "Jazz" };

    //            //now have a list of all the strings
    //            var quotedasdfs = string.Join(", ", asdfs.Select(tag => $"'{tag}'"));

    //            var discogsTagsInTheDbAlready = @$"SELECT Id, DiscogsTag
    //                                               FROM DiscogsGenreTags
    //                                               WHERE DiscogsTag IN ({quotedasdfs});
    //                                                    ";
    //            var discogsTagsResponse = await _db.QueryAsync<DiscogsTagDto>(discogsTagsInTheDbAlready);

    //            foreach (var tag in discogsTagsResponse) { Console.WriteLine(tag.DiscogsTag); }

    //            ////_________________________________________________________________________________________________________________________________________
    //            ///select single record
    //            ///



    //            var oneRecordQuery = @$"SELECT DiscogsReleaseId FROM Release LIMIT 1;";
                                                       
    //            var oneREcordResponse = await _db.QueryAsync<DiscogsReleaseIdClass>(oneRecordQuery);

    //            Console.WriteLine(oneREcordResponse.Select(x => x.DiscogsReleaseId).First());
                ////_________________________________________________________________________________________________________________________________________
                ///artist ids
                ///

                var discogsArtistIdsFromRelease = new List<int>
                {
                    371334,
                    218605,
                    255047,
                    230387,
                    258372,
                    85889,
                    1049161,
                    38781,
                    82730,
                    243955,
                    246650,
                    1485641,
                    162617,
                    48412,
                    2830806,
                    39765,
                    12345,123455
                };

                //do a query like the below:
                //var artistIdsInString = string.Join(", ", discogsArtistIdsFromRelease);

                //var discogsArtistsInTheDbAlready = @$"SELECT DiscogsArtistId
                //                                           FROM Artist
                //                                           WHERE DiscogsArtistId IN ({artistIdsInString});
                //                                                ";


                //var artitsInResponse = await _db.QueryAsync<DiscogsArtistIdClass>(discogsArtistsInTheDbAlready);

                //foreach (var item in artitsInResponse)
                //{
                //    Console.WriteLine(item.DiscogsArtistId);
                //}

                #endregion
                ////_________________________________________________________________________________________________________________________________________
                ////_________________________________________________________________________________________________________________________________________
                ////_________________________________________________________________________________________________________________________________________
                ////_________________________________________________________________________________________________________________________________________

                var discogsArtistInTheDbAlready = @$"SELECT DiscogsArtistId FROM Artist";

                var artistsIdsInDbAlreadyInterim = await _db.QueryAsync<DiscogsArtistIdClass>(discogsArtistInTheDbAlready);


                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
            }
        }
    }


    //helper classes

    public class DiscogsTagDto
    {
        public string Id { get; set; }
        public string DiscogsTag { get; set; }
    }
    public class CountClass
    {
        public int Count { get; set; }
    }
    public class DiscogsReleaseIdClass
    {
        public int DiscogsReleaseId { get; set; }
    }
    
    public class DiscogsArtistIdClass
    {
        public int DiscogsArtistId { get; set; }
    }
    
    public class MusicBrainzReleaseIdResponse
    {
        public string MusicBrainzReleaseId { get; set; }
    }
    public class ReleaseInterimData
    {
        public string? Year { get; set; }
        public string? OriginalReleaseYear { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? ReleaseNotes { get; set; }
        public string? ReleaseCountry { get; set; }
        public int? DiscogsArtistId { get; set; }
        public int? DiscogsReleaseId { get; set; }
        public string MusicBrainzReleaseId { get; set; }
        public string? DiscogsReleaseUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool IsFavourited { get; set; }
        public bool HasAllApiData { get; set; }
    }
}