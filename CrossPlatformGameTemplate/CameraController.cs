using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Entities.Mario;

namespace SuperMario
{
    public class CameraController
    {
        Camera screenCamera;
        Viewport graphicsViewport;
        float zoom;
        int levelWidth;
        int playerIndex;

        public CameraController(Viewport viewport, int levelHeight, int lvlWidth, int playerIndex)
        {
            graphicsViewport = viewport;
            zoom = (float)viewport.Height / levelHeight;
            levelWidth = lvlWidth;
            this.playerIndex = playerIndex;
            screenCamera = new Camera(zoom);
        }

        public void Update()
        {
            MarioEntity playerEntity = (MarioEntity)EntityStorage.Instance.PlayerEntityList[playerIndex];
            float centerCameraXPos = graphicsViewport.Bounds.Center.X / zoom;
            centerCameraXPos -= (graphicsViewport.Width / zoom) * playerIndex;
            float cameraEndCenterXPos = levelWidth - centerCameraXPos;
            Vector2 newCameraLocation;
            float newYPos = 0;

            if (playerEntity.PlayerUnderground)
                newYPos = -340;

            if (centerCameraXPos <= playerEntity.BoundingBox.X && screenCamera.Location.X <= playerEntity.BoundingBox.X && cameraEndCenterXPos >= playerEntity.BoundingBox.X)
            {
                float newXPos = playerEntity.BoundingBox.X - centerCameraXPos;
                newCameraLocation = new Vector2(newXPos, newYPos);
            }
            else if (cameraEndCenterXPos < playerEntity.BoundingBox.X)
            {
                float newXPos = cameraEndCenterXPos - centerCameraXPos;
                newCameraLocation = new Vector2(newXPos, newYPos);
            }
            else
                newCameraLocation = Vector2.Zero;

            screenCamera.LookAt(newCameraLocation);
        }

        public Matrix TransformationMatrix => screenCamera.Transform;

        internal class Camera
        {
            public Matrix Transform { get; private set; }
            public Vector2 Location { get; private set; }
            private Vector3 originLocation;
            private Vector3 zoomMatrix;

            float matrixConstant = 1f;

            public Camera(Vector2 location, float zoom)
            {
                zoomMatrix = new Vector3(zoom, zoom, matrixConstant);
                Location = location;
                originLocation = Vector3.Zero;
                CreateTransformationMatrix();
            }

            public Camera(float zoom) : this(Vector2.Zero, zoom) { }

            public void CreateTransformationMatrix()
            {
                Transform = Matrix.CreateTranslation(new Vector3(-Location, 0.0f))
                    * Matrix.CreateScale(zoomMatrix)
                    * Matrix.CreateTranslation(originLocation);
            }

            public void LookAt(Vector2 location)
            {
                Location = location;
                CreateTransformationMatrix();
            }
        }
    }
}
