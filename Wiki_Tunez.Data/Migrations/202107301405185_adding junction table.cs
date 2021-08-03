namespace Wiki_Tunez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingjunctiontable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "Playlist_Id", "dbo.Playlist");
            DropForeignKey("dbo.Playlist", "SongId", "dbo.Song");
            DropForeignKey("dbo.Song", "Id", "dbo.Album");
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropIndex("dbo.Song", new[] { "Playlist_Id" });
            DropIndex("dbo.Playlist", new[] { "SongId" });
            DropPrimaryKey("dbo.Album");
            CreateTable(
                "dbo.PlaylistSong",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlaylistId, t.SongId })
                .ForeignKey("dbo.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Song", t => t.SongId, cascadeDelete: true)
                .Index(t => t.PlaylistId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.PlaylistSong1",
                c => new
                    {
                        Playlist_Id = c.Int(nullable: false),
                        Song_SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_Id, t.Song_SongId })
                .ForeignKey("dbo.Playlist", t => t.Playlist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Song", t => t.Song_SongId, cascadeDelete: true)
                .Index(t => t.Playlist_Id)
                .Index(t => t.Song_SongId);
            
            DropColumn("dbo.Album", "Id");
            AddColumn("dbo.Album", "AlbumId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Song", "AlbumId", c => c.Int());
            AddPrimaryKey("dbo.Album", "AlbumId");
            CreateIndex("dbo.Song", "AlbumId");
            AddForeignKey("dbo.Song", "AlbumId", "dbo.Album", "AlbumId");
            DropColumn("dbo.Song", "Playlist_Id");
            DropColumn("dbo.Playlist", "SongId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlist", "SongId", c => c.Int(nullable: false));
            AddColumn("dbo.Song", "Playlist_Id", c => c.Int());
            AddColumn("dbo.Album", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.PlaylistSong", "SongId", "dbo.Song");
            DropForeignKey("dbo.PlaylistSong", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.PlaylistSong1", "Song_SongId", "dbo.Song");
            DropForeignKey("dbo.PlaylistSong1", "Playlist_Id", "dbo.Playlist");
            DropIndex("dbo.PlaylistSong1", new[] { "Song_SongId" });
            DropIndex("dbo.PlaylistSong1", new[] { "Playlist_Id" });
            DropIndex("dbo.PlaylistSong", new[] { "SongId" });
            DropIndex("dbo.PlaylistSong", new[] { "PlaylistId" });
            DropIndex("dbo.Song", new[] { "AlbumId" });
            DropPrimaryKey("dbo.Album");
            DropColumn("dbo.Song", "AlbumId");
            DropColumn("dbo.Album", "AlbumId");
            DropTable("dbo.PlaylistSong1");
            DropTable("dbo.PlaylistSong");
            AddPrimaryKey("dbo.Album", "Id");
            CreateIndex("dbo.Playlist", "SongId");
            CreateIndex("dbo.Song", "Playlist_Id");
            AddForeignKey("dbo.Song", "AlbumId", "dbo.Album", "AlbumId");
            AddForeignKey("dbo.Song", "Id", "dbo.Album", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Playlist", "SongId", "dbo.Song", "SongId", cascadeDelete: true);
            AddForeignKey("dbo.Song", "Playlist_Id", "dbo.Playlist", "Id");
        }
    }
}
