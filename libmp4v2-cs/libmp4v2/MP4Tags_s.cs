namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4Tags_s : StructPtr<libmp4v2.Internal.MP4Tags_s>
    {
        public MP4Tags_s()
        {
        }

        public MP4Tags_s(libmp4v2.Internal.MP4Tags_s value) : base(value)
        {
        }

        internal MP4Tags_s(StructPtr<libmp4v2.Internal.MP4Tags_s> other) : base(other)
        {
        }

        public MP4Tags_s(libmp4v2.Internal.MP4Tags_s[] value) : base(value)
        {
        }

        public MP4Tags_s(int arraySize) : base(arraySize)
        {
        }

        public MP4Tags_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4Tags_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4Tags_s(pointer);
        }

        public static implicit operator libmp4v2.MP4Tags_s(libmp4v2.Internal.MP4Tags_s value)
        {
            return new libmp4v2.MP4Tags_s(value);
        }

        public static implicit operator libmp4v2.MP4Tags_s(IntPtr value)
        {
            return new libmp4v2.MP4Tags_s(value);
        }

        public IntPtr __handle
        {
            get
            {
                return base.ReadIntPtrFromField(0L);
            }
            set
            {
                base.WriteIntPtrToField(0L, value);
            }
        }

        public ByteArrayPtr album
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x10L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x10L, (IPinnable) value);
            }
        }

        public ByteArrayPtr albumArtist
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(12L);
            }
            set
            {
                base.SetPinnableToIntPtrField(12L, (IPinnable) value);
            }
        }

        public ByteArrayPtr artist
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(8L);
            }
            set
            {
                base.SetPinnableToIntPtrField(8L, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> artistID
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(0xb8L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xb8L, (IPinnable) value);
            }
        }

        public MP4TagArtwork artwork
        {
            get
            {
                return base.GetPinnableFromIntPtrField<MP4TagArtwork>(0x74L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x74L, (IPinnable) value);
            }
        }

        public UInt32 artworkCount
        {
            get
            {
                return base.ReadStructFromField<UInt32>(120L);
            }
            set
            {
                base.WriteStructToField<UInt32>(120L, value);
            }
        }

        public ByteArrayPtr category
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x94L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x94L, (IPinnable) value);
            }
        }

        public ByteArrayPtr comments
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x1cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x1cL, (IPinnable) value);
            }
        }

        public ByteArrayPtr compilation
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x38L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x38L, (IPinnable) value);
            }
        }

        public ByteArrayPtr composer
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x18L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x18L, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> composerID
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(0xc4L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xc4L, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> contentID
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(180L);
            }
            set
            {
                base.SetPinnableToIntPtrField(180L, (IPinnable) value);
            }
        }

        public ByteArrayPtr contentRating
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(160L);
            }
            set
            {
                base.SetPinnableToIntPtrField(160L, (IPinnable) value);
            }
        }

        public ByteArrayPtr copyright
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x7cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x7cL, (IPinnable) value);
            }
        }

        public ByteArrayPtr description
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(80L);
            }
            set
            {
                base.SetPinnableToIntPtrField(80L, (IPinnable) value);
            }
        }

        public MP4TagDisk disk
        {
            get
            {
                return base.GetPinnableFromIntPtrField<MP4TagDisk>(0x30L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x30L, (IPinnable) value);
            }
        }

        public ByteArrayPtr encodedBy
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x84L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x84L, (IPinnable) value);
            }
        }

        public ByteArrayPtr encodingTool
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x80L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x80L, (IPinnable) value);
            }
        }

        public ByteArrayPtr gapless
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0xa4L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xa4L, (IPinnable) value);
            }
        }

        public ByteArrayPtr genre
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x20L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x20L, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> genreID
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(0xc0L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xc0L, (IPinnable) value);
            }
        }

        public ShortArrayPtr genreType
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ShortArrayPtr>(0x24L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x24L, (IPinnable) value);
            }
        }

        public ByteArrayPtr grouping
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(20L);
            }
            set
            {
                base.SetPinnableToIntPtrField(20L, (IPinnable) value);
            }
        }

        public ByteArrayPtr hdVideo
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x98L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x98L, (IPinnable) value);
            }
        }

        public libmp4v2.MP4Tags_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4Tags_s) base.GetAtIndex(index);
            }
        }

        public ByteArrayPtr iTunesAccount
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0xa8L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xa8L, (IPinnable) value);
            }
        }

        public ByteArrayPtr iTunesAccountType
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0xacL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xacL, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> iTunesCountry
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(0xb0L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xb0L, (IPinnable) value);
            }
        }

        public ByteArrayPtr keywords
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x90L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x90L, (IPinnable) value);
            }
        }

        public ByteArrayPtr longDescription
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x54L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x54L, (IPinnable) value);
            }
        }

        public ByteArrayPtr lyrics
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x58L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x58L, (IPinnable) value);
            }
        }

        public ByteArrayPtr mediaType
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x9cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x9cL, (IPinnable) value);
            }
        }

        public ByteArrayPtr name
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(4L);
            }
            set
            {
                base.SetPinnableToIntPtrField(4L, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt64> playlistID
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt64>>(0xbcL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0xbcL, (IPinnable) value);
            }
        }

        public ByteArrayPtr podcast
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(140L);
            }
            set
            {
                base.SetPinnableToIntPtrField(140L, (IPinnable) value);
            }
        }

        public ByteArrayPtr purchaseDate
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x88L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x88L, (IPinnable) value);
            }
        }

        public ByteArrayPtr releaseDate
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(40L);
            }
            set
            {
                base.SetPinnableToIntPtrField(40L, (IPinnable) value);
            }
        }

        public ByteArrayPtr sortAlbum
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x68L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x68L, (IPinnable) value);
            }
        }

        public ByteArrayPtr sortAlbumArtist
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(100L);
            }
            set
            {
                base.SetPinnableToIntPtrField(100L, (IPinnable) value);
            }
        }

        public ByteArrayPtr sortArtist
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x60L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x60L, (IPinnable) value);
            }
        }

        public ByteArrayPtr sortComposer
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x6cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x6cL, (IPinnable) value);
            }
        }

        public ByteArrayPtr sortName
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x5cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x5cL, (IPinnable) value);
            }
        }

        public ByteArrayPtr sortTVShow
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x70L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x70L, (IPinnable) value);
            }
        }

        public ShortArrayPtr tempo
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ShortArrayPtr>(0x34L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x34L, (IPinnable) value);
            }
        }

        public MP4TagTrack track
        {
            get
            {
                return base.GetPinnableFromIntPtrField<MP4TagTrack>(0x2cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x2cL, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> tvEpisode
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(0x4cL);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x4cL, (IPinnable) value);
            }
        }

        public ByteArrayPtr tvEpisodeID
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x44L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x44L, (IPinnable) value);
            }
        }

        public ByteArrayPtr tvNetwork
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0x40L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x40L, (IPinnable) value);
            }
        }

        public ArrayPtr<UInt32> tvSeason
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ArrayPtr<UInt32>>(0x48L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0x48L, (IPinnable) value);
            }
        }

        public ByteArrayPtr tvShow
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(60L);
            }
            set
            {
                base.SetPinnableToIntPtrField(60L, (IPinnable) value);
            }
        }

        public ByteArrayPtr xid
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(200L);
            }
            set
            {
                base.SetPinnableToIntPtrField(200L, (IPinnable) value);
            }
        }
    }
}

