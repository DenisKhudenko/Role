using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EntityInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "group_parameters",
                columns: table => new
                {
                    guid = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    name_json = table.Column<string>(type: "text", nullable: false),
                    IsGroup = table.Column<bool>(type: "boolean", nullable: false),
                    ParentGUID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_parameters", x => x.guid);
                    table.ForeignKey(
                        name: "FK_group_parameters_group_parameters_ParentGUID",
                        column: x => x.ParentGUID,
                        principalTable: "group_parameters",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_groups",
                columns: table => new
                {
                    guid = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_groups", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    guid = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "user_groups_parameters",
                columns: table => new
                {
                    ParametersGUID = table.Column<string>(type: "text", nullable: false),
                    UserGroupsGUID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_groups_parameters", x => new { x.ParametersGUID, x.UserGroupsGUID });
                    table.ForeignKey(
                        name: "FK_user_groups_parameters_group_parameters_ParametersGUID",
                        column: x => x.ParametersGUID,
                        principalTable: "group_parameters",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_groups_parameters_user_groups_UserGroupsGUID",
                        column: x => x.UserGroupsGUID,
                        principalTable: "user_groups",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_user_groups",
                columns: table => new
                {
                    UserGroupsGUID = table.Column<string>(type: "text", nullable: false),
                    UsersGUID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_user_groups", x => new { x.UserGroupsGUID, x.UsersGUID });
                    table.ForeignKey(
                        name: "FK_user_user_groups_user_groups_UserGroupsGUID",
                        column: x => x.UserGroupsGUID,
                        principalTable: "user_groups",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_user_groups_users_UsersGUID",
                        column: x => x.UsersGUID,
                        principalTable: "users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_group_parameters_ParentGUID",
                table: "group_parameters",
                column: "ParentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_user_groups_parameters_UserGroupsGUID",
                table: "user_groups_parameters",
                column: "UserGroupsGUID");

            migrationBuilder.CreateIndex(
                name: "IX_user_user_groups_UsersGUID",
                table: "user_user_groups",
                column: "UsersGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_groups_parameters");

            migrationBuilder.DropTable(
                name: "user_user_groups");

            migrationBuilder.DropTable(
                name: "group_parameters");

            migrationBuilder.DropTable(
                name: "user_groups");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
