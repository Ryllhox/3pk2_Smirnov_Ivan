using System.Collections.Generic;

namespace pz_010.Backroll;

record Album(Stack<Photo> photos);

//class Album
//{
//    public Stack<Photo> photos { get; set; }
//    //{ get { if (photos.Count < 1) LastPhoto(); return photos; } set { photos = value; } }

//    public Album()
//    {
//        photos = new Stack<Photo>();
//    }

//    private Stack<Photo> LastPhoto()
//    {
//        if (photos.Count < 1) photos.Push(new Photo(new FlowDocument(null)));
//        return photos;
//    }
//}