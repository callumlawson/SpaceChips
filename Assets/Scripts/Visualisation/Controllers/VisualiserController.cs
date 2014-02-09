using UnityEngine;

namespace Assets.Scripts.Visualisation.Controllers
{
    public abstract class VisualiserController
    {
        protected GameObject ComponentGameObject;
        private readonly Component component;
        private readonly EngineEvents engineEvents;
        private readonly string componentPath;

        protected VisualiserController(EngineEvents engineEvents, Component component, string componentPath)
        {
            this.componentPath = componentPath;
            this.engineEvents = engineEvents;
            this.component = component;

            CreateModel();
          
            engineEvents.OnUpdate += OnUpdate;
            component.OnComponentDestroyed += Destroy;
        }

        private void CreateModel()
        {
            ComponentGameObject = Object.Instantiate(Resources.Load<GameObject>(componentPath)) as GameObject;
            if (ComponentGameObject == null)
            {
                Debug.LogError("Unable to instantiate: " + ComponentGameObject + ", is the resource path correct?");
            }
        }

        private void Destroy()
        {
            Object.Destroy(ComponentGameObject);
            engineEvents.OnUpdate -= OnUpdate;
            component.OnComponentDestroyed -= Destroy;
        }

        protected abstract void OnUpdate();
    }
}
