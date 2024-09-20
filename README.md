# Azure Open AI in Blazor using Microsoft Semantic Kernel in a chatbot UI

## Set up

Once you create an Azure OpenAI resource in Azure, get the `Endpoint` value from the **Overview** menu and the `Key` from the **Keys and Endpoint** menu.

From the **Overview** page, click on the "*Go to Azure OpenAI Studio*" button. Once you deploy a model from there, get the `Model name` as this will be your **ModelId** secret, and the `DeploymentName`.

Open a terminal and cd into the `AOAI.Blazor.Demo` directory. Execute these commands:

```Powershell
dotnet user-secrets init
dotnet user-secrets set "AOAI:DeploymentName" "<Your deployment name>"
dotnet user-secrets set "AOAI:Endpoint" "<Your endpoint>"
dotnet user-secrets set "AOAI:Key" "<Your key>"
dotnet user-secrets set "AOAI:ModelId" "<Your model id>"
dotnet user-secrets list
```

Alternatively, you can just edit the `appconfig.json` files with those values. Just be careful not to check that in to your source code repository.

## Running application

Once you run the web app in your browser, navigate to the **Settings** page and set the "*What Am I*" field then click the "*Set What Am I*" button. This will serve as the system message. It will store this value in your localstorage so you don't have to keep setting this value every time you run the application. You can change this later by navigating back to this page.

The chatbot component is set to always be visible in any page. If you don't see the chat icon in the lower part of the page right away just refresh the page. As soon as you open the chat popup, you'll be greeted and can now chat with Azure Open AI. Press enter at end of prompt, or click the send icon.
