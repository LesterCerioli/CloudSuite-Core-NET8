using CloudSuite.Domain.Enums;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class Media : Entity, IAggregateRoot
    {

        public Media(string? caption, int? fileSize, string? fileName, MediaType mediaType) {
            Caption = caption;
            FileSize = fileSize;
            FileName = fileName;
            MediaType = mediaType;
        }

        public Media() { }

        public string? Caption { get; private set; }

        public int? FileSize { get; private set; }

        public string? FileName { get; private set; }

        public MediaType MediaType { get; private set; }
    }
}