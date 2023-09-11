using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbServiceEFCoreV4.DbMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(nullable: true, defaultValue: "Created")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CameraConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraName = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoExtensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoExtensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoExtensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoExtensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationModificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraName = table.Column<string>(nullable: true),
                    ActionsID = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationModificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationModificationDetails_Actions_ActionsID",
                        column: x => x.ActionsID,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraConfigurationID = table.Column<int>(nullable: false),
                    ActionsID = table.Column<int>(nullable: false),
                    FolderPath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    StartTimestamp = table.Column<DateTime>(nullable: false),
                    EndTimestamp = table.Column<DateTime>(nullable: false),
                    FileExtension = table.Column<string>(nullable: true),
                    IsVideo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitoringDetails_Actions_ActionsID",
                        column: x => x.ActionsID,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitoringDetails_CameraConfigurations_CameraConfigurationID",
                        column: x => x.CameraConfigurationID,
                        principalTable: "CameraConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folder_CameraConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraConfigurationId = table.Column<int>(nullable: false),
                    FolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder_CameraConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folder_CameraConfiguration_CameraConfigurations_CameraConfigurationId",
                        column: x => x.CameraConfigurationId,
                        principalTable: "CameraConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folder_CameraConfiguration_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoExtension_CameraConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraConfigurationId = table.Column<int>(nullable: false),
                    PhotoExtensionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoExtension_CameraConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoExtension_CameraConfiguration_CameraConfigurations_CameraConfigurationId",
                        column: x => x.CameraConfigurationId,
                        principalTable: "CameraConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoExtension_CameraConfiguration_PhotoExtensions_PhotoExtensionId",
                        column: x => x.PhotoExtensionId,
                        principalTable: "PhotoExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoExtension_CameraConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraConfigurationId = table.Column<int>(nullable: false),
                    VideoExtensionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoExtension_CameraConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoExtension_CameraConfiguration_CameraConfigurations_CameraConfigurationId",
                        column: x => x.CameraConfigurationId,
                        principalTable: "CameraConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoExtension_CameraConfiguration_VideoExtensions_VideoExtensionId",
                        column: x => x.VideoExtensionId,
                        principalTable: "VideoExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folder_ConfigurationModificationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationModificationDetailId = table.Column<int>(nullable: false),
                    FolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder_ConfigurationModificationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folder_ConfigurationModificationDetail_ConfigurationModificationDetails_ConfigurationModificationDetailId",
                        column: x => x.ConfigurationModificationDetailId,
                        principalTable: "ConfigurationModificationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folder_ConfigurationModificationDetail_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoExtension_ConfigurationModificationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoExtensionId = table.Column<int>(nullable: false),
                    ConfigurationModificationDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoExtension_ConfigurationModificationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoExtension_ConfigurationModificationDetail_ConfigurationModificationDetails_ConfigurationModificationDetailId",
                        column: x => x.ConfigurationModificationDetailId,
                        principalTable: "ConfigurationModificationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoExtension_ConfigurationModificationDetail_PhotoExtensions_PhotoExtensionId",
                        column: x => x.PhotoExtensionId,
                        principalTable: "PhotoExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoExtension_ConfigurationModificationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoExtensionId = table.Column<int>(nullable: false),
                    ConfigurationModificationDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoExtension_ConfigurationModificationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoExtension_ConfigurationModificationDetail_ConfigurationModificationDetails_ConfigurationModificationDetailId",
                        column: x => x.ConfigurationModificationDetailId,
                        principalTable: "ConfigurationModificationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoExtension_ConfigurationModificationDetail_VideoExtensions_VideoExtensionId",
                        column: x => x.VideoExtensionId,
                        principalTable: "VideoExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "Action" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 4, "Modified" },
                    { 3, "Deleted" },
                    { 2, "Added" }
                });

            migrationBuilder.InsertData(
                table: "PhotoExtensions",
                columns: new[] { "Id", "Extension" },
                values: new object[,]
                {
                    { 20, "k25" },
                    { 19, "nrw" },
                    { 18, "rw2" },
                    { 17, "cr" },
                    { 16, "arw" },
                    { 14, "psd" },
                    { 13, "tif" },
                    { 12, "tiff" },
                    { 11, "webp" },
                    { 15, "raw" },
                    { 9, "svgz" },
                    { 8, "svg" },
                    { 7, "png" },
                    { 6, "jfif" },
                    { 5, "jif" },
                    { 4, "jpe" },
                    { 3, "jfi" },
                    { 2, "jpeg" },
                    { 1, "jpg" },
                    { 10, "pdf" }
                });

            migrationBuilder.InsertData(
                table: "VideoExtensions",
                columns: new[] { "Id", "Extension" },
                values: new object[,]
                {
                    { 12, "avc" },
                    { 11, "avchd" },
                    { 10, "wmv" },
                    { 9, "avi" },
                    { 8, "ogg" },
                    { 7, "webm" },
                    { 2, "mp2" },
                    { 5, "mpe" },
                    { 4, "mpeg" },
                    { 3, "mp3" },
                    { 1, "mpg" },
                    { 13, "mp4" },
                    { 6, "mpv" },
                    { 14, "m4p" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationModificationDetails_ActionsID",
                table: "ConfigurationModificationDetails",
                column: "ActionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_CameraConfiguration_CameraConfigurationId",
                table: "Folder_CameraConfiguration",
                column: "CameraConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_CameraConfiguration_FolderId",
                table: "Folder_CameraConfiguration",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_ConfigurationModificationDetail_ConfigurationModificationDetailId",
                table: "Folder_ConfigurationModificationDetail",
                column: "ConfigurationModificationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_ConfigurationModificationDetail_FolderId",
                table: "Folder_ConfigurationModificationDetail",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringDetails_ActionsID",
                table: "MonitoringDetails",
                column: "ActionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringDetails_CameraConfigurationID",
                table: "MonitoringDetails",
                column: "CameraConfigurationID");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoExtension_CameraConfiguration_CameraConfigurationId",
                table: "PhotoExtension_CameraConfiguration",
                column: "CameraConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoExtension_CameraConfiguration_PhotoExtensionId",
                table: "PhotoExtension_CameraConfiguration",
                column: "PhotoExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoExtension_ConfigurationModificationDetail_ConfigurationModificationDetailId",
                table: "PhotoExtension_ConfigurationModificationDetail",
                column: "ConfigurationModificationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoExtension_ConfigurationModificationDetail_PhotoExtensionId",
                table: "PhotoExtension_ConfigurationModificationDetail",
                column: "PhotoExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoExtension_CameraConfiguration_CameraConfigurationId",
                table: "VideoExtension_CameraConfiguration",
                column: "CameraConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoExtension_CameraConfiguration_VideoExtensionId",
                table: "VideoExtension_CameraConfiguration",
                column: "VideoExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoExtension_ConfigurationModificationDetail_ConfigurationModificationDetailId",
                table: "VideoExtension_ConfigurationModificationDetail",
                column: "ConfigurationModificationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoExtension_ConfigurationModificationDetail_VideoExtensionId",
                table: "VideoExtension_ConfigurationModificationDetail",
                column: "VideoExtensionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folder_CameraConfiguration");

            migrationBuilder.DropTable(
                name: "Folder_ConfigurationModificationDetail");

            migrationBuilder.DropTable(
                name: "MonitoringDetails");

            migrationBuilder.DropTable(
                name: "PhotoExtension_CameraConfiguration");

            migrationBuilder.DropTable(
                name: "PhotoExtension_ConfigurationModificationDetail");

            migrationBuilder.DropTable(
                name: "VideoExtension_CameraConfiguration");

            migrationBuilder.DropTable(
                name: "VideoExtension_ConfigurationModificationDetail");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "PhotoExtensions");

            migrationBuilder.DropTable(
                name: "CameraConfigurations");

            migrationBuilder.DropTable(
                name: "ConfigurationModificationDetails");

            migrationBuilder.DropTable(
                name: "VideoExtensions");

            migrationBuilder.DropTable(
                name: "Actions");
        }
    }
}
