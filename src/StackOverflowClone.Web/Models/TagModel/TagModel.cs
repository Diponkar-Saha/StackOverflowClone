using Autofac;
using StackOverflowClone.Application.Services;
using StackOverflowClone.Application.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StackOverflowClone.Web.Models.TagModel
{
    public class TagModel
    {
        [DisplayName("Tag Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string TagName { get; set; }

        [DisplayName("Tag Description")]
        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string TagDescription { get; set; }

        public IList<Tag>? Tags = new List<Tag>();

        private ITagService _tagService;

        public TagModel()
        {

        }

        public TagModel(ITagService tagService)
        {
            _tagService = tagService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _tagService = scope.Resolve<ITagService>();
        }

        internal async Task Load()
        {
            Tags = await _tagService.GetAllTag();
        }
        internal async Task Add()
        {
            var tag = new Tag
            {
                TagName = TagName,
                TagDescription = TagDescription
            };

            await _tagService.AddTag(tag);
        }
        internal async Task Delete(Guid id)
        {
            await _tagService.DeleteTag(id);
        }
    }
}
