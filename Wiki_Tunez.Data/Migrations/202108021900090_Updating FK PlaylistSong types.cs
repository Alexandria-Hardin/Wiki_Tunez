namespace Wiki_Tunez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingFKPlaylistSongtypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistSong1", "Playlist_Id", "dbo.Playlist");
            DropForeignKey("dbo.PlaylistSong1", "Song_SongId", "dbo.Song");
            DropIndex("dbo.PlaylistSong1", new[] { "Playlist_Id" });
            DropIndex("dbo.PlaylistSong1", new[] { "Song_SongId" });
            DropTable("dbo.PlaylistSong1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaylistSong1",
                c => new
                    {
                        Playlist_Id = c.Int(nullable: false),
                        Song_SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_Id, t.Song_SongId });
            
            CreateIndex("dbo.PlaylistSong1", "Song_SongId");
            CreateIndex("dbo.PlaylistSong1", "Playlist_Id");
            AddForeignKey("dbo.PlaylistSong1", "Song_SongId", "dbo.Song", "SongId", cascadeDelete: true);
            AddForeignKey("dbo.PlaylistSong1", "Playlist_Id", "dbo.Playlist", "Id", cascadeDelete: true);
        }
    }
}
