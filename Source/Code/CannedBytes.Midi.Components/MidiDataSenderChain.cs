namespace CannedBytes.Midi.Components
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The MidiSenderChain class provides a chaining implementation for sender chain components.
    /// </summary>
    public class MidiDataSenderChain : DisposableBase, IChainOf<IMidiDataSender>
    {
        /// <summary>
        /// Call to relay the short midi message data to the next sender component in the chain.
        /// </summary>
        /// <param name="data">The short midi message data.</param>
        /// <remarks>The method will fail graciously if the <see cref="Next"/> property is not set.</remarks>
        protected void NextSenderShortData(int data)
        {
            if (this.Next != null)
            {
                this.Next.ShortData(data);
            }
        }

        /// <summary>
        /// Call to relay the long midi message data to the next sender component in the chain.
        /// </summary>
        /// <param name="buffer">The long midi message data.</param>
        /// <remarks>The method will fail graciously if the <see cref="Next"/> property is not set.</remarks>
        protected void NextSenderLongData(MidiBufferStream buffer)
        {
            Contract.Requires(buffer != null);
            Throw.IfArgumentNull(buffer, "buffer");

            if (this.Next != null)
            {
                this.Next.LongData(buffer);
            }
        }

        /// <summary>
        /// Gets or sets the next sender component this instance will call.
        /// </summary>
        public IMidiDataSender Next { get; set; }
    }
}