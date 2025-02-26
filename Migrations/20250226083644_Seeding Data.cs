using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lingo.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "CodeName", "Name" },
                values: new object[,]
                {
                    { new Guid("35aa616e-9d5a-411c-bb33-04a7ec0b2281"), "NAR", "North America" },
                    { new Guid("5c97203c-30af-48e7-993a-29a316fab220"), "ASA", "Asia" },
                    { new Guid("6c3fe7a0-5b12-4a5e-9435-b6d96edfffe4"), "ATA", "Antarctica" },
                    { new Guid("a5f9d466-b3ac-4e80-9c6a-2730626dce25"), "AFA", "Africa" },
                    { new Guid("c8841377-d6a4-477e-8102-08fc0edc7cec"), "EUO", "Europe" },
                    { new Guid("caab9054-dc6d-451d-a7ff-64704cf2b8cb"), "AUS", "Australia" },
                    { new Guid("d646b273-fcd4-4d5f-8269-5d2a0638dcd2"), "SAR", "South America" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CodeName", "Name" },
                values: new object[,]
                {
                    { new Guid("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"), "USA", "United States America" },
                    { new Guid("8f348057-b5f9-4f47-85b2-8ce65a91b7bb"), "CHN", "China" },
                    { new Guid("947664b6-25a2-42ad-b920-b427391b97b6"), "UK", "United Kingdom" },
                    { new Guid("9811952c-744c-4bae-91b3-14b4a4d2ee3e"), "ITA", "Italy" },
                    { new Guid("9ed2d84b-bd42-4d20-965e-01e147f8c3c0"), "SA", "SouthAfrica" }
                });

            migrationBuilder.InsertData(
                table: "StrongLevels",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"), "Mild/Casual Slang" },
                    { new Guid("1c8b6236-74f1-40ac-a127-a0f8b572432b"), "Moderate Slang" },
                    { new Guid("d44ed0a3-72f8-4e8c-810b-3dbb270366d5"), "Strong/Potentially Offensive Slang" }
                });

            migrationBuilder.InsertData(
                table: "Slangs",
                columns: new[] { "Id", "ContinentId", "CountryId", "Meaning", "StrongLevelId", "Word" },
                values: new object[,]
                {
                    { new Guid("0854b55b-dfc4-4b44-9efc-32a9d883b88a"), new Guid("c8841377-d6a4-477e-8102-08fc0edc7cec"), new Guid("947664b6-25a2-42ad-b920-b427391b97b6"), "Extremely tired or exhausted", new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"), "Knackered" },
                    { new Guid("2f66ce89-bb29-49da-92de-e645dfcb8fab"), new Guid("35aa616e-9d5a-411c-bb33-04a7ec0b2281"), new Guid("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"), "A gay man", new Guid("d44ed0a3-72f8-4e8c-810b-3dbb270366d5"), "Faggot" },
                    { new Guid("329eb9d0-147b-4467-b680-b8e52e9a2d76"), new Guid("c8841377-d6a4-477e-8102-08fc0edc7cec"), new Guid("9811952c-744c-4bae-91b3-14b4a4d2ee3e"), "Means that's good or thank God", new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"), "Meno male" },
                    { new Guid("5a3c1374-9f3c-4a96-a555-566403c28973"), new Guid("35aa616e-9d5a-411c-bb33-04a7ec0b2281"), new Guid("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"), "Means a lie", new Guid("1c8b6236-74f1-40ac-a127-a0f8b572432b"), "Cap" },
                    { new Guid("84e55f54-2214-4145-8cf3-ee28943fc189"), new Guid("5c97203c-30af-48e7-993a-29a316fab220"), new Guid("8f348057-b5f9-4f47-85b2-8ce65a91b7bb"), "An Ugly Boy", new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"), "làiháma" },
                    { new Guid("a6b4703b-4a0e-4a7b-9ffd-9bdca7a9338b"), new Guid("a5f9d466-b3ac-4e80-9c6a-2730626dce25"), new Guid("9ed2d84b-bd42-4d20-965e-01e147f8c3c0"), "the washing of your face and teeth only, instead of your whole body ", new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"), "ID photo" },
                    { new Guid("c620e736-31e4-415d-aff4-945c77209f65"), new Guid("35aa616e-9d5a-411c-bb33-04a7ec0b2281"), new Guid("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"), "Exciting, amazing, or excellent", new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"), "Lit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("6c3fe7a0-5b12-4a5e-9435-b6d96edfffe4"));

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("caab9054-dc6d-451d-a7ff-64704cf2b8cb"));

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("d646b273-fcd4-4d5f-8269-5d2a0638dcd2"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("0854b55b-dfc4-4b44-9efc-32a9d883b88a"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("2f66ce89-bb29-49da-92de-e645dfcb8fab"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("329eb9d0-147b-4467-b680-b8e52e9a2d76"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("5a3c1374-9f3c-4a96-a555-566403c28973"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("84e55f54-2214-4145-8cf3-ee28943fc189"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("a6b4703b-4a0e-4a7b-9ffd-9bdca7a9338b"));

            migrationBuilder.DeleteData(
                table: "Slangs",
                keyColumn: "Id",
                keyValue: new Guid("c620e736-31e4-415d-aff4-945c77209f65"));

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("35aa616e-9d5a-411c-bb33-04a7ec0b2281"));

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("5c97203c-30af-48e7-993a-29a316fab220"));

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("a5f9d466-b3ac-4e80-9c6a-2730626dce25"));

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: new Guid("c8841377-d6a4-477e-8102-08fc0edc7cec"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8f348057-b5f9-4f47-85b2-8ce65a91b7bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("947664b6-25a2-42ad-b920-b427391b97b6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9811952c-744c-4bae-91b3-14b4a4d2ee3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9ed2d84b-bd42-4d20-965e-01e147f8c3c0"));

            migrationBuilder.DeleteData(
                table: "StrongLevels",
                keyColumn: "Id",
                keyValue: new Guid("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"));

            migrationBuilder.DeleteData(
                table: "StrongLevels",
                keyColumn: "Id",
                keyValue: new Guid("1c8b6236-74f1-40ac-a127-a0f8b572432b"));

            migrationBuilder.DeleteData(
                table: "StrongLevels",
                keyColumn: "Id",
                keyValue: new Guid("d44ed0a3-72f8-4e8c-810b-3dbb270366d5"));
        }
    }
}
