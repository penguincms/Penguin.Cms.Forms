using Penguin.Cms.Entities;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Penguin.Cms.Forms
{
    /// <summary>
    /// This class forms the basis for both Json Forms and Concrete Form implementations.
    /// </summary>
    /// As such it needs to be coded in
    /// a way that allows new instances of concrete forms to pretend to be json form instances. This is why it has some wonkey overrides
    /// to set properties that would be instance properties on Json Forms. Dont touch them unless you can replace them
    [SuppressMessage("Naming", "CA1720:Identifier contains type name")]
    public abstract class Form : AuditableEntity
    {
        private const string CANT_SET_GUID_MESSAGE = "Cant set guid on concrete from implementation";

        [DontAllow(DisplayContexts.Edit | DisplayContexts.BatchEdit)]
        [Display(Name = "Friendly Url")]
        public virtual string FriendlyUrl => $"/Form/{this.Name.Replace(" ", "-")}";

        [DontAllow(DisplayContexts.Edit)]
        public override Guid Guid
        {
            get
            {
                if (this.IsJsonForm)
                {
                    return base.Guid;
                }
                else
                {
                    return new Guid(this.GetType().GetHashCode(), 0, 0, new byte[8]);
                }
            }
            set
            {
                if (this.IsJsonForm)
                {
                    //This hurts to do since this value should never be set, but since I havent
                    //blocked it yet, it needs to be consistant
                    base.Guid = value;
                }
                else
                {
                    throw new UnauthorizedAccessException(CANT_SET_GUID_MESSAGE);
                }
            }
        }

        public virtual bool IsJsonForm => false;

        public virtual string Name
        {
            get => this.GetType().GetCustomAttribute<DisplayAttribute>()?.Name ?? this.ExternalId.Replace("-", " ");
            set { }
        }

        [DontAllow(DisplayContexts.Edit | DisplayContexts.BatchEdit)]
        [Display(Name = "Permanent Url")]
        public virtual string PermanentUrl => this.FriendlyUrl;
    }
}