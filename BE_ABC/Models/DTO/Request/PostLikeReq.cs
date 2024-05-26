﻿using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class PostLikeReq
    {
        public string userId { get; set; }
        public int postId { get; set; }
        public StatusType status { get; set; }

    }
}
