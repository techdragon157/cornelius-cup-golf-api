﻿using CorneliusCup.Golf.API.Entities;

namespace CorneliusCup.Golf.API.Requests
{
    public class TeeRequest<T>
    {
        public int Id { get; set; }

        public TeeType TeeType { get; set; }

        public int Par { get; set; }

        public int SSS { get; set; }

        public int CourseRating { get; set; }

        public int SlopeRating { get; set; }

        public IEnumerable<T> HoleDetails { get; set; } = new List<T>();
    }

    public class TeeRequest : TeeRequest<HoleDetailRequest> { }

}