using System;
using System.Diagnostics;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Commands
    {
        [Command("hello")]
        public async Task Hello(CommandContext context)
        {
            await context.RespondAsync($"👋 Hi, {context.User.Mention}!");
        }

        [Command("scream")]
        public async Task Anime(CommandContext context)
        {
            await context.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {
                Title = "Reina Screams!",
                ImageUrl = "https://i.imgur.com/RYSN83m.png"
            };
            await context.RespondAsync("", embed: embed);
        }
    }
}
