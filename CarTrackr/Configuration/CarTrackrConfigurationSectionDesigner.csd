<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel dslVersion="1.0.0.0" Id="d8e43d6f-20ef-4fdf-b10c-719eb7f287e2" namespace="CarTrackr.Configuration" xmlSchemaNamespace="CarTrackr.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <configurationElements>
    <configurationSection name="CarTrackrConfigurationSection" namespace="CarTrackr.Configuration" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="carTrackrConfigurationSection">
      <elementProperties>
        <elementProperty name="serviceStations" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="serviceStations" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d8e43d6f-20ef-4fdf-b10c-719eb7f287e2/ServiceStationCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="ServiceStation" namespace="CarTrackr.Configuration">
      <attributeProperties>
        <attributeProperty name="name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d8e43d6f-20ef-4fdf-b10c-719eb7f287e2/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="logoUrl" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="logoUrl" isReadOnly="false" defaultValue="&quot;/Content/ServiceStations/none.gif&quot;">
          <type>
            <externalTypeMoniker name="/d8e43d6f-20ef-4fdf-b10c-719eb7f287e2/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="ServiceStationCollection" namespace="CarTrackr.Configuration" collectionType="AddRemoveClearMap" xmlItemName="serviceStation" codeGenOptions="Indexer, AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/d8e43d6f-20ef-4fdf-b10c-719eb7f287e2/ServiceStation" />
      </itemType>
    </configurationElementCollection>
  </configurationElements>
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
</configurationSectionModel>