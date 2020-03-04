namespace InfinitusApp.Core.Data.DataModels
{
    public enum DataItemMediaType
    {
        Unknown,
        Generic,
        Image,
        Video,
        Audio,
        Document,
        Curriculum
    }

    public enum SpecialMedia
    {
        None,
        Media3D
    }

    public class DataItemMedia : Naylah.Core.Entities.EntityBase
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string ResourceUri { get; set; }

        public string ThumbnailUri { get; set; }

        public DataItemMediaType Type { get; set; }

        public string DataItemId { get; set; }

        public int SizeByte { get; set; }

        public SpecialMedia SpecialMediaType { get; set; }
    }
}