using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Dynamics;

namespace Pancakes.Engine.Physics
{
    /// <summary>
    /// A utility class that simplifies registering collision callbacks with Farseer physics objects.
    /// </summary>
    public static class CollisionUtilities
    {
        /// <summary>
        /// Delegate invoked when a collision between two fixtures occur.
        /// </summary>
        /// <typeparam name="T">Filters collision callbacks to be restricted to a specific type.</typeparam>
        /// <param name="fixtureTo">The fixture being collided with.</param>
        /// <param name="collidedWith">The entity who owns the from fixture.</param>
        /// <param name="fixtureFrom">The fixture colliding into another.</param>
        /// <param name="contact">Some data about the collision (Farseer object).</param>
        /// <returns>Flag which allows implementors to invalidate a collision, thus preventing it from happening.</returns>
        public delegate bool CollisionDelegate<T>(Fixture fixtureTo, T collidedWith, Fixture fixtureFrom, Contact contact) where T : Entity;

        /// <summary>
        /// Delegate invoked when two fixtures are no longer colliding.
        /// </summary>
        /// <typeparam name="T">Filters seperation callbacks to be restricted to a specific type.</typeparam>
        /// <param name="fixtureTo">The fixture being seperated from.</param>
        /// <param name="collidedWith">The entity who owns the from fixture.</param>
        /// <param name="fixtureFrom">The fixture seperating from another.</param>
        public delegate void SeparationDelegate<T>(Fixture fixtureTo, T collidedWith, Fixture fixtureFrom) where T : Entity;

        /// <summary>
        /// Register a collision callback with a physics body.
        /// </summary>
        /// <typeparam name="T">Filter collisions so the callback only happens for collisions with this type.</typeparam>
        /// <param name="physBody">The body to register the callback with.</param>
        /// <param name="callback">The callback that will be invoked upon a collision.</param>
        public static void RegisterOnCollidedListener<T>(this Body physBody, CollisionDelegate<T> callback) where T : Entity
        {
            physBody.OnCollision += delegate(Fixture f1, Fixture f2, Contact c)
            {
                if (f1.Body == physBody && f2.Body.UserData is T)
                    c.Enabled = callback(f1, f2.Body.UserData as T, f2, c);
                else if (f1.Body.UserData is T)
                    c.Enabled = callback(f2, f1.Body.UserData as T, f1, c);

                return c.Enabled;
            };
        }

        /// <summary>
        /// Register a collision callback with a physics body's specific fixture.
        /// </summary>
        /// <typeparam name="T">Filter collisions so the callback only happens for collisions with this type.</typeparam>
        /// <param name="fixture">The fixture to register the callback with.</param>
        /// <param name="callback">The callback that will be invoked upon a collision.</param>
        public static void RegisterOnCollidedListener<T>(this Fixture fixture, CollisionDelegate<T> callback) where T : Entity
        {
            fixture.OnCollision += delegate(Fixture f1, Fixture f2, Contact c)
            {
                if (f1 == fixture && f2.Body.UserData is T)
                    c.Enabled = callback(f1, f2.Body.UserData as T, f2, c);
                else if (f1.Body.UserData is T)
                    c.Enabled = callback(f2, f1.Body.UserData as T, f1, c);

                return c.Enabled;
            };
        }

        /// <summary>
        /// Register a seperation callback with a physics body.
        /// </summary>
        /// <typeparam name="T">Filter seperations so the callback only happens for sepertions with this type.</typeparam>
        /// <param name="physBody">The body to register the callback with.</param>
        /// <param name="callback">The callback that will be invoked upon a seperation.</param>
        public static void RegisterOnSeparatedListener<T>(this Body physBody, SeparationDelegate<T> callback) where T : Entity
        {
            physBody.OnSeparation += delegate(Fixture f1, Fixture f2)
            {
                if (f1.Body == physBody && f2.Body.UserData is T)
                    callback(f1, f2.Body.UserData as T, f2);
                else if (f1.Body.UserData is T)
                    callback(f2, f1.Body.UserData as T, f1);
            };
        }

        /// <summary>
        /// Register a seperation callback with a physics body's specific fixture.
        /// </summary>
        /// <typeparam name="T">Filter seperations so the callback only happens for sepertions with this type.</typeparam>
        /// <param name="fixture">The fixture to register the callback with.</param>
        /// <param name="callback">The callback that will be invoked upon a seperation.</param>
        public static void RegisterOnSeparatedListener<T>(this Fixture fixture, SeparationDelegate<T> callback) where T : Entity
        {
            fixture.OnSeparation += delegate(Fixture f1, Fixture f2)
            {
                if (f1 == fixture && f2.Body.UserData is T)
                    callback(f1, f2.Body.UserData as T, f2);
                else if (f1.Body.UserData is T)
                    callback(f2, f1.Body.UserData as T, f1);
            };
        }
    }
}
