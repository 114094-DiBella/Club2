using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCarrera = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Carreras_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Legajo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Legajo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docentes_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlumnosCurso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProfesor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnosCurso_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnosCurso_Docentes_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocenteCurso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDocente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Docentes_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_IdRole",
                table: "Alumnos",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosCurso_IdCurso",
                table: "AlumnosCurso",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosCurso_IdProfesor",
                table: "AlumnosCurso",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdCarrera",
                table: "Cursos",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_IdCurso",
                table: "DocenteCurso",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_IdDocente",
                table: "DocenteCurso",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_IdRole",
                table: "Docentes",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "AlumnosCurso");

            migrationBuilder.DropTable(
                name: "DocenteCurso");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
