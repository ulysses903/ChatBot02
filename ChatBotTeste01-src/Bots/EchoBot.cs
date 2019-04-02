// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Microsoft.Bot.Builder.EchoBot
{
    public class EchoBot : ActivityHandler
    {
        public EchoBot()
        {
        }

        /// <summary>
        /// Every conversation turn calls this method.
        /// </summary>
        /// <param name="turnContext">A <see cref="ITurnContext"/> containing all the data needed
        /// for processing this conversation turn. </param>
        /// <param name="cancellationToken">(Optional) A <see cref="CancellationToken"/> that can be used by other objects
        /// or threads to receive notice of cancellation.</param>
        /// <returns>A <see cref="Task"/> that represents the work queued to execute.</returns>
        /// <seealso cref="BotStateSet"/>
        /// <seealso cref="ConversationState"/>
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Handle Message activity type, which is the main activity type for shown within a conversational interface
            // Message activities may contain text, speech, interactive cards, and binary or unknown attachments.
            // see https://aka.ms/about-bot-activity-message to learn more about the message and other activity types
            string responseMessage = turnContext.Activity.Text;

            if (responseMessage.ToLower() == "ola" || responseMessage.ToLower() == "oi")
            {
                await turnContext.SendActivityAsync("Ola, qual seu nome?");
            }

            else if (responseMessage == "Ulysses")
            {
                await turnContext.SendActivityAsync("Muito prazer Ulysses. O que Gostaria?");
            }

            else if (responseMessage == "Um estagio")
            {
                await turnContext.SendActivityAsync("Peça ao Mauricio");
            }

            else
            {
                // Echo back to the user whatever they typed.             
                await turnContext.SendActivityAsync("Tente outra pergunta.", cancellationToken: cancellationToken);
            }
        }
}
