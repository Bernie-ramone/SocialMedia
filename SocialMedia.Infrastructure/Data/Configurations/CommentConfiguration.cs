﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(e => e.CommentId);

            builder.Property(e => e.CommentId).ValueGeneratedNever().HasColumnName("IdComentario");
            builder.Property(e => e.PostId).ValueGeneratedNever().HasColumnName("IdPublicacion");
            builder.Property(e => e.UserId).ValueGeneratedNever().HasColumnName("IdUsuario");
            builder.Property(e => e.IsActive).ValueGeneratedNever().HasColumnName("Activo");

            builder.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnType("datetime").HasColumnName("Fecha");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}