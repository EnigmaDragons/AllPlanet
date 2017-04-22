using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Common;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace MonoDragons.Core.Engine
{
    public static class World
    {
        private static readonly Events _events = new Events();
        private static readonly Events _persistentEvents = new Events();
        private static readonly List<EventSubscription> _eventSubs = new List<EventSubscription>();

        public static int CurrentEventSubscriptionCount => _events.SubscriptionCount + _persistentEvents.SubscriptionCount;

        private static Game _game;
        private static ContentManager _content;
        private static SpriteBatch _spriteBatch;
        private static INavigation _navigation;

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch)
        {
            _game = game;
            _content = game.Content;
            _navigation = navigation;
            _spriteBatch = spriteBatch;
            DefaultFont.Load(_content);
        }

        public static void Draw(Texture2D texture, Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(texture, rectangle, color);
        }

        public static void NavigateToScene(string sceneName)
        {
            Resources.Unload();
            _navigation.NavigateTo(sceneName);
        }

        public static void DrawBackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(Resources.Load<Texture2D>(imageName), pixelPosition);
        }

        public static void Draw(string imageName, Rectangle rectPostion)
        {
            _spriteBatch.Draw(Resources.Load<Texture2D>(imageName), rectPostion, Color.White);
        }

        public static void Draw(Texture2D texture, Rectangle rectPosition)
        {
            Resources.Put(texture.GetHashCode().ToString(), texture);
            _spriteBatch.Draw(texture, rectPosition, Color.White);
        }

        [DebuggerStepThrough]
        public static void Publish<T>(T payload)
        {
            _events.Publish(payload);
            _persistentEvents.Publish(payload);
        }

        public static void Subscribe(EventSubscription subscription)
        {
            _persistentEvents.Subscribe(subscription);
        }

        public static void SubscribeForScene(EventSubscription subscription)
        {
            _events.Subscribe(subscription);
            _eventSubs.Add(subscription);
            Resources.Put(subscription.GetHashCode().ToString(), subscription);
        }

        public static void Unsubscribe(object owner)
        {
            _events.Unsubscribe(owner);
            _persistentEvents.Unsubscribe(owner);
            _eventSubs.Where(x => x.Owner.Equals(owner)).ForEach(x => 
                {
                    Resources.NotifyDisposed(x);
                    _eventSubs.Remove(x);
                });
        }

        public static void Draw(Texture2D texture, Vector2 position)
        {
            _spriteBatch.Draw(texture, position);
        }

        public static void Draw(string name, Transform2 transform)
        {
            Draw(name, transform.ToRectangle());
        }

        public static void Draw(Texture2D texture, Transform2 transform)
        {
            Draw(texture, transform.ToRectangle());
        }
    }
}
