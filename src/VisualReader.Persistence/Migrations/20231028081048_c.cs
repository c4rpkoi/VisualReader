using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisualReader.Persistence.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truyen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTruyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhBia = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AgeRatting = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: false),
                    LuotXem = table.Column<int>(type: "int", nullable: false),
                    LuotDanhGia = table.Column<int>(type: "int", nullable: false),
                    SoLuongTheoDoi = table.Column<int>(type: "int", nullable: false),
                    XepHang = table.Column<float>(type: "real", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truyen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_type_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    verified = table.Column<bool>(type: "bit", nullable: false),
                    locked = table.Column<bool>(type: "bit", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTruyenCuaTruyen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiTruyenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruyenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTruyenCuaTruyen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoaiTruyenCuaTruyen_Truyen_TruyenID",
                        column: x => x.TruyenID,
                        principalTable: "Truyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TacGiaTruyen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TacGiaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruyenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGiaTruyen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TacGiaTruyen_Truyen_TruyenID",
                        column: x => x.TruyenID,
                        principalTable: "Truyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheLoaiTruyen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruyenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheLoaiID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoaiTruyen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TheLoaiTruyen_Truyen_TruyenID",
                        column: x => x.TruyenID,
                        principalTable: "Truyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "block",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTruyen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_block_Truyen_IdTruyen",
                        column: x => x.IdTruyen,
                        principalTable: "Truyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_block_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dsdangdoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    summary = table.Column<int>(type: "int", nullable: false),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dsdangdoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dsdangdoc_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dsquantam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTruyen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loaiquantam = table.Column<int>(type: "int", nullable: false),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dsquantam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dsquantam_Truyen_IdTruyen",
                        column: x => x.IdTruyen,
                        principalTable: "Truyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dsquantam_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_details_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruyenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTruyenCuaTruyenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ma = table.Column<float>(type: "real", nullable: false),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LuotXem = table.Column<int>(type: "int", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_LoaiTruyenCuaTruyen_LoaiTruyenCuaTruyenID",
                        column: x => x.LoaiTruyenCuaTruyenID,
                        principalTable: "LoaiTruyenCuaTruyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dsdadoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTruyen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDsDangDoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    chapter = table.Column<int>(type: "int", nullable: false),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dsdadoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dsdadoc_dsdangdoc_IdDsDangDoc",
                        column: x => x.IdDsDangDoc,
                        principalTable: "dsdangdoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dsdadoc_Truyen_IdTruyen",
                        column: x => x.IdTruyen,
                        principalTable: "Truyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookmark",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChapter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pageinformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookmark_Chapters_IdChapter",
                        column: x => x.IdChapter,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookmark_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    chapter_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_Chapters_chapter_id",
                        column: x => x.chapter_id,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_block_IdTruyen",
                table: "block",
                column: "IdTruyen");

            migrationBuilder.CreateIndex(
                name: "IX_block_IdUser",
                table: "block",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_bookmark_IdChapter",
                table: "bookmark",
                column: "IdChapter");

            migrationBuilder.CreateIndex(
                name: "IX_bookmark_IdUser",
                table: "bookmark",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_LoaiTruyenCuaTruyenID",
                table: "Chapters",
                column: "LoaiTruyenCuaTruyenID");

            migrationBuilder.CreateIndex(
                name: "IX_comment_book_id",
                table: "comment",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_chapter_id",
                table: "comment",
                column: "chapter_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_id",
                table: "comment",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_id",
                table: "comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_dsdadoc_IdDsDangDoc",
                table: "dsdadoc",
                column: "IdDsDangDoc");

            migrationBuilder.CreateIndex(
                name: "IX_dsdadoc_IdTruyen",
                table: "dsdadoc",
                column: "IdTruyen");

            migrationBuilder.CreateIndex(
                name: "IX_dsdangdoc_IdUser",
                table: "dsdangdoc",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dsquantam_IdTruyen",
                table: "dsquantam",
                column: "IdTruyen");

            migrationBuilder.CreateIndex(
                name: "IX_dsquantam_IdUser",
                table: "dsquantam",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiTruyenCuaTruyen_TruyenID",
                table: "LoaiTruyenCuaTruyen",
                column: "TruyenID");

            migrationBuilder.CreateIndex(
                name: "IX_TacGiaTruyen_TruyenID",
                table: "TacGiaTruyen",
                column: "TruyenID");

            migrationBuilder.CreateIndex(
                name: "IX_TheLoaiTruyen_TruyenID",
                table: "TheLoaiTruyen",
                column: "TruyenID");

            migrationBuilder.CreateIndex(
                name: "IX_user_details_user_id",
                table: "user_details",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "block");

            migrationBuilder.DropTable(
                name: "bookmark");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "dsdadoc");

            migrationBuilder.DropTable(
                name: "dsquantam");

            migrationBuilder.DropTable(
                name: "TacGiaTruyen");

            migrationBuilder.DropTable(
                name: "TheLoaiTruyen");

            migrationBuilder.DropTable(
                name: "user_details");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "dsdangdoc");

            migrationBuilder.DropTable(
                name: "LoaiTruyenCuaTruyen");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Truyen");
        }
    }
}
